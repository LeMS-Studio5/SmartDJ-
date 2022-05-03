using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace SmartDJ__{
    public partial class Form1 : Form{
        Dictionary<String,SongDetails> fileTags = new Dictionary<String, SongDetails>();
        Dictionary<String, double> Songscores = new Dictionary<String, double>();
        public Form1(){
            InitializeComponent();
            LoadDirs();
            LoadScores();
            CompareFiles();
        }
        private void LoadDirs()
        {
            if (Properties.Settings.Default.Paths != null)
            {
                for (int i= 0;i < Properties.Settings.Default.Paths.Count;i++)
                {
                    String lin = Properties.Settings.Default.Paths[i];
                    if (Directory.Exists(lin))
                    {
                        ScanFolder(lin);
                    }
                    else
                    {
                        if(MessageBox.Show(lin +" can not be found, would you like to remove it from the library?", "Folder can't be found", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Properties.Settings.Default.Paths.RemoveAt(i);
                        }
                    }
                }
            }
        }
        private void LoadScores()
        {
            if (Properties.Settings.Default.Scores!=null)
            {
                for (int i = 0; i < Properties.Settings.Default.Scores.Count; i++)
                {
                    String lin = Properties.Settings.Default.Scores[i];
                    if (lin != null && lin.Contains(","))
                    {
                        if (!fileTags.ContainsKey(lin.Split(',')[0]) || !fileTags.ContainsKey(lin.Split(',')[1].Split(':')[0])) { Properties.Settings.Default.Scores.RemoveAt(i); i--; }
                        else
                            Songscores.Add(lin.Split(':')[0], double.Parse(lin.Split(':')[1]));
                    }else if (lin == null)
                    {
                        Properties.Settings.Default.Scores.RemoveAt(i);
                        i--;
                    }
                }
            }
            Properties.Settings.Default.Save();
        }
        private String id(SongDetails song){
            if (song.MusicBrainzTrackId != null) return song.MusicBrainzTrackId; else return song.Title + song.Duration.TotalMilliseconds;
        }
        private void ScanFolder(string dirPath) {
            var fils = Directory.GetFiles(dirPath, "*.mp3", SearchOption.AllDirectories);
            List<ListViewItem> lviList1 = new List<ListViewItem>();
            List<ListViewItem> lviList2 = new List<ListViewItem>();
            fils.AsParallel().ForAll(fil =>
            {
                try
                {
                    Status("Loading " + fil);
                    SongDetails S = new SongDetails(fil);
                    if (!fileTags.ContainsKey(id(S)))
                    {
                        ListViewItem l = new ListViewItem("?");
                        l.Tag = id(S);
                        l.SubItems.Add(S.Title);
                        l.SubItems.Add(S.Album);
                        l.SubItems.Add(S.JoinedAlbumArtists);
                        l.SubItems.Add(S.JoinedGenres);
                        l.SubItems.Add(S.Year.ToString());
                        lviList1.Add(l);
                        lviList2.Add((ListViewItem)l.Clone());
                        fileTags.Add(id(S), S);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
            listView1.Items.AddRange(lviList1.ToArray());
            listView2.Items.AddRange(lviList2.ToArray());
        }
        private void btnOpenFolders_Click(object sender, EventArgs e){
            if (fbdMusic.ShowDialog() == DialogResult.OK) {
                if (Properties.Settings.Default.Paths == null) Properties.Settings.Default.Paths = new System.Collections.Specialized.StringCollection();
                Properties.Settings.Default.Paths.Add(fbdMusic.SelectedPath);
                ScanFolder(fbdMusic.SelectedPath);
                CompareFiles();
              }
        }
        private String idsOrdered(String id1,String id2)
        {
            String[] ids = new String[] { id1, id2 };
            Array.Sort(ids);
            return ids[0]+","+ids[1];
        }
        private void CompareFiles()
        {
            if (Properties.Settings.Default.Scores == null) Properties.Settings.Default.Scores = new System.Collections.Specialized.StringCollection();
            fileTags.AsParallel().ForAll(keyValue =>
            {
                foreach (KeyValuePair<String, SongDetails> keyValue2 in fileTags)
                {
                    String k = idsOrdered(keyValue.Key, keyValue2.Key);
                    if (!Songscores.ContainsKey(k))
                    {
                        Status("Comparing " + keyValue.Value.Title + " to " + keyValue2.Value.Title);
                        double s = Compare(keyValue.Value, keyValue2.Value);
                        Songscores.Add(k, s);
                        //if (!Properties.Settings.Default.Scores.
                        if (!Properties.Settings.Default.Scores.Contains(k + ":" + s))
                            Properties.Settings.Default.Scores.Add(k + ":" + s);
                    }
                }
            Properties.Settings.Default.Save();
            });
        }
        private double inAnotherArray(String[] arr1,String[] arr2){
            if (arr1.Length == 0 && arr2.Length == 0) return 100;
            if (arr1.Length == 0 || arr2.Length == 0) return 0;
            double v = 0.0,total=arr1.Length*arr2.Length;
            Dictionary<String,String> d1 = arr1.ToDictionary(i => i, t => t);
            for(int i=0; i < arr2.Length; i++){
                if (d1.ContainsKey(arr2[i])) { 
                    v += 100;
                    if (total>arr2.Length)total -= arr2.Length;
                }else{
                    foreach (String a1 in arr1){
                        v += CompareStrings(a1, arr2[i]);
                    }
                }
            }
            return (v / total);
        }
        private double Compare(SongDetails fil1, SongDetails fil2){
            double dblSim = 0;
            dblSim += CompareStrings(fil1.Album, fil2.Album);
            dblSim += inAnotherArray(fil1.AlbumArtists, fil2.AlbumArtists);
            dblSim += CompareStrings(fil1.Title, fil2.Title);
            dblSim += YearDif(fil1.Year, fil2.Year);
            dblSim += inAnotherArray(fil1.Genres, fil2.Genres);
            dblSim += inAnotherArray(fil1.Composers, fil2.Composers);
            dblSim += inAnotherArray(fil1.Performers, fil2.Performers);
            dblSim += keyDif(fil1.InitialKey, fil2.InitialKey);
            dblSim += BPMDif(fil1.BeatsPerMinute, fil2.BeatsPerMinute);
            dblSim += TimeDif(fil1.Duration.TotalSeconds, fil2.Duration.TotalSeconds);
            dblSim += CompareStrings(fil1.RecordLabel, fil2.RecordLabel);
            dblSim += CompareStrings(fil1.MusicBrainzReleaseCountry, fil2.MusicBrainzReleaseCountry);
            dblSim += CompareStrings(fil1.Language, fil2.Language);
            return dblSim / 13.0;
        }
        private void Status(String msg)
        {
            Console.WriteLine(msg);
        }
        private void btnCompare_Click(object sender, EventArgs e){
            String fil1 = listView1.FocusedItem.Tag.ToString();
            for (int i=0; i < listView2.Items.Count; i++){
                listView2.Items[i].SubItems[0].Text = Songscores[idsOrdered(fil1, listView2.Items[i].Tag.ToString())].ToString("000.00");
            }
            listView2.Sort();
        }
        private double CompareStrings(String str1, String str2){
            if (str1 == str2) return 100.0;
            if (str1 == "" || str2=="") return 0.0;
            return ((CalculateSimilarity(str1, str2)*150)+(50 - Math.Abs(string.Compare(str1, str2, System.Globalization.CultureInfo.CurrentCulture, System.Globalization.CompareOptions.OrdinalIgnoreCase))))/2;
           }
        //LINES 87 TO 121 FROM https://www.techdoubts.net/2018/10/measure-similarity-of-2-strings-levenshtein.html
        double CalculateSimilarity(string source, string target){
            if ((source == null) && (target == null)) return 1.0;
            if ((source == null) || (target == null)) return 0.0;
            if ((source.Length == 0) || (target.Length == 0)) return 0.0;
            if (source == target) return 1.0;
            int stepsToSame = ComputeLevenshteinDistance(source, target);
            return (1.0 - ((double)stepsToSame / (double)Math.Max(source.Length, target.Length)));
        }
        /// <summary>
        /// Returns the number of steps required to transform the source string
        /// into the target string.
        /// </summary>
        int ComputeLevenshteinDistance(string source, string target){
            if ((source == null) || (target == null)) return 0;
            if ((source.Length == 0) || (target.Length == 0)) return 0;
            if (source == target) return source.Length;
            int sourceWordCount = source.Length;
            int targetWordCount = target.Length;
            // Step 1
            if (sourceWordCount == 0) return targetWordCount;
            if (targetWordCount == 0) return sourceWordCount;
            int[,] distance = new int[sourceWordCount + 1, targetWordCount + 1];
            // Step 2
            for (int i = 0; i <= sourceWordCount; distance[i, 0] = i++) ;
            for (int j = 0; j <= targetWordCount; distance[0, j] = j++) ;
            for (int i = 1; i <= sourceWordCount; i++){
                for (int j = 1; j <= targetWordCount; j++){
                    // Step 3
                    int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;
                    // Step 4
                    distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
                }
            }
            return distance[sourceWordCount, targetWordCount];
        }
        private void btnDetails_Click(object sender, EventArgs e){
            ltvDetail.Items.Clear();
            SongDetails fil1 = fileTags[listView1.FocusedItem.Tag.ToString()];
            SongDetails fil2 = fileTags[listView2.FocusedItem.Tag.ToString()];
            List<ListViewItem> itms = new List<ListViewItem>();
            itms.Add(new ListViewItem(new string[] {"Album", fil1.Album, fil2.Album, CompareStrings(fil1.Album, fil2.Album).ToString()}));
            itms.Add(new ListViewItem(new string[] { "AlbumArtists", fil1.JoinedAlbumArtists, fil2.JoinedAlbumArtists, inAnotherArray(fil1.AlbumArtists, fil2.AlbumArtists).ToString()}));
            itms.Add(new ListViewItem(new string[] { "Title", fil1.Title, fil2.Title, CompareStrings(fil1.Title, fil2.Title).ToString()}));
            itms.Add(new ListViewItem(new string[] { "Year", fil1.Year.ToString(), fil2.Year.ToString(), YearDif(fil1.Year,  fil2.Year).ToString()}));
            itms.Add(new ListViewItem(new string[] {"Genre", fil1.JoinedGenres, fil2.JoinedGenres, inAnotherArray(fil1.Genres, fil2.Genres).ToString()}));
            itms.Add(new ListViewItem(new string[] { "Composers", fil1.JoinedComposers, fil2.JoinedComposers, inAnotherArray(fil1.Composers, fil2.Composers).ToString()}));
            itms.Add(new ListViewItem(new string[] { "Performers", fil1.JoinedPerformers, fil2.JoinedPerformers, inAnotherArray(fil1.Performers, fil2.Performers).ToString()}));
            itms.Add(new ListViewItem(new string[] { "InitialKey", fil1.InitialKey, fil2.InitialKey, keyDif(fil1.InitialKey, fil2.InitialKey).ToString()}));
            itms.Add(new ListViewItem(new string[] {"BPM", fil1.BeatsPerMinute.ToString(), fil2.BeatsPerMinute.ToString(), BPMDif(fil1.BeatsPerMinute, fil2.BeatsPerMinute).ToString()}));
            itms.Add(new ListViewItem(new string[] { "TotalSeconds", fil1.Duration.TotalSeconds.ToString(), fil2.Duration.TotalSeconds.ToString(), TimeDif(fil1.Duration.TotalSeconds, fil2.Duration.TotalSeconds).ToString()}));
            itms.Add(new ListViewItem(new string[] { "Record Label", fil1.RecordLabel, fil2.RecordLabel, CompareStrings(fil1.RecordLabel, fil2.RecordLabel).ToString() }));
            itms.Add(new ListViewItem(new string[] { "Country", fil1.MusicBrainzReleaseCountry, fil2.MusicBrainzReleaseCountry, CompareStrings(fil1.MusicBrainzReleaseCountry, fil2.MusicBrainzReleaseCountry).ToString() }));
            itms.Add(new ListViewItem(new string[] { "Language", fil1.Language, fil2.Language, CompareStrings(fil1.Language,fil2.Language).ToString() }));
            ltvDetail.Items.AddRange(itms.ToArray());
            //lblSecondSong.Text = "Second Song: " + fil2.Title;
            lblScore.Text = "Overall Score: " +Compare(fil1, fil2).ToString("000.00");
        }
        private double BPMDif(Int32 bpm1, Int32 bpm2){
            if (bpm1== bpm2) return 100;
            if (bpm1 < 40 || bpm2 < 40) return 0;
            return 100-((Math.Abs(bpm1 - bpm2)/280.0)*100.0);
        }
        private double TimeDif(double tim1, double tim2){
            return 100 - (Math.Abs(tim1 - tim2) / Math.Max(tim1,tim2) * 100.0);
        }
        private double YearDif(Int32 year1, Int32 year2){
            if (year1<1859 && year2 < 1859) return 100;
            if (year1 < 1859 || year2 < 1859) return 0;
            return Math.Abs(100 - Math.Abs(year1-year2));
        }
        private double keyDif(String key1, String key2){
            if (key1==null && key2==null) return 100;
            if (key1 == null || key2 == null) return 0;
            key1=key1.Replace('♯', 'S').Replace('#', 'S').Replace('♭', 'F');
            key2 = key2.Replace('#', 'S').Replace('#', 'S').Replace('♭', 'F');
            double dblScore= 100 - Math.Abs((((Keys)Enum.Parse(typeof(Keys), key1.Replace("m", "")) - (Keys)Enum.Parse(typeof(Keys), key2.Replace("m", ""))) / 1000.0));
            if ((key1.EndsWith("m") && !key2.EndsWith("m")) || key2.EndsWith("m") && !key1.EndsWith("m")) dblScore -= 50;
            return dblScore;
            }
        public enum Keys{
            AF=40625,
            A=00000,
            AS=3125,
            BF=3125,
            B=06250,
            BS=12500,
            CF=06250,
            C=12500,
            CS=15625,
            DF=15625,
            D=18750,
            DS=21875,
            EF=21875,
            E=25000,
            ES=31250,
            FF=25000,
            F=31250,
            FS=34375,
            GF=34375,
            G =37500,
            GS=40625,
            //AFm = 40625,
            //Am = 50000,
            //ASm = 53125,
            //BFm = 53125,
            //Bm = 56250,
            //BSm = 62500,
            //CFm = 56250,
            //Cm = 62500,
            //CSm = 65625,
            //DFm = 65625,
            //Dm = 68750,
            //DSm = 71875,
            //EFm = 71875,
            //Em = 75000,
            //ESm = 81250,
            //FFm = 75000,
            //Fm = 81250,
            //FSm = 84375,
            //GFm = 84375,
            //Gm = 87500,
            //GSm = 90625,
        }
    }
}