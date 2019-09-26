namespace ZbW.Testing.Dms.Client.Model
{
    using System;

    public class MetadataItem
    {
        public string FilePfad { get; set; }

        public string Bezeichnung { get; set; }

        public DateTime ValutaDatum { get; set; }

        public string Typ { get; set; }

        public string Stichwoerter { get; set; }

        public DateTime Erfassungsdatum { get; set; }

        public string Benutzer { get; set; }

        public bool DateiAnschliessendLöschen { get; set; }

        public MetadataItem()
        {
        }

        public MetadataItem(string filePfad, string bezeichnung, DateTime valutaDatum, string typ, 
                            DateTime erfassungsdatum, string benutzer, bool dateiAnschliessendLöschen)
        {
            FilePfad = filePfad;
            Bezeichnung = bezeichnung;
            ValutaDatum = valutaDatum;
            Typ = typ;
            Erfassungsdatum = erfassungsdatum;
            Benutzer = benutzer;
            DateiAnschliessendLöschen = dateiAnschliessendLöschen;
        }

        public MetadataItem(
            string filePfad,
            string bezeichnung,
            DateTime valutaDatum,
            string typ,
            string stichwoerter,
            DateTime erfassungsdatum,
            string benutzer,
            bool dateiAnschliessendLöschen)
        {
            FilePfad = filePfad;
            Bezeichnung = bezeichnung;
            ValutaDatum = valutaDatum;
            Typ = typ;
            Stichwoerter = stichwoerter;
            Erfassungsdatum = erfassungsdatum;
            Benutzer = benutzer;
            DateiAnschliessendLöschen = dateiAnschliessendLöschen;
        }
        public MetadataItem(string bezeichnung,DateTime valutaDatum)
        {
            Bezeichnung = bezeichnung;
            ValutaDatum = valutaDatum;
        }
    }
}