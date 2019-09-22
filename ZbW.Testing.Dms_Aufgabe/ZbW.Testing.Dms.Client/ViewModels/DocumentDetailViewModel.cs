namespace ZbW.Testing.Dms.Client.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Dynamic;
    using System.IO;
    using System.Windows;

    using Microsoft.Win32;

    using Prism.Commands;
    using Prism.Mvvm;

    using ZbW.Testing.Dms.Client.Model;
    using ZbW.Testing.Dms.Client.Repositories;
    using ZbW.Testing.Dms.Client.Services;

    internal class DocumentDetailViewModel : BindableBase
    {
        private readonly Action _navigateBack;

        private string _benutzer;

        private string _bezeichnung;

        private DateTime _erfassungsdatum;

        private string _filePath;

        private bool _isRemoveFileEnabled;

        private string _selectedTypItem;

        private string _stichwoerter;

        private List<string> _typItems;

        private DateTime? _valutaDatum;

        public DocumentDetailViewModel(string benutzer, Action navigateBack)
        {
            _navigateBack = navigateBack;
            Benutzer = benutzer;
            Erfassungsdatum = DateTime.Now;
            TypItems = ComboBoxItems.Typ;

            CmdDurchsuchen = new DelegateCommand(OnCmdDurchsuchen);
            CmdSpeichern = new DelegateCommand(OnCmdSpeichern);
        }

        public string Stichwoerter
        {
            get
            {
                return _stichwoerter;
            }

            set
            {
                SetProperty(ref _stichwoerter, value);
            }
        }

        public string Bezeichnung
        {
            get
            {
                return _bezeichnung;
            }

            set
            {
                SetProperty(ref _bezeichnung, value);
            }
        }

        public List<string> TypItems
        {
            get
            {
                return _typItems;
            }

            set
            {
                SetProperty(ref _typItems, value);
            }
        }

        public string SelectedTypItem
        {
            get
            {
                return _selectedTypItem;
            }

            set
            {
                SetProperty(ref _selectedTypItem, value);
            }
        }

        public DateTime Erfassungsdatum
        {
            get
            {
                return _erfassungsdatum;
            }

            set
            {
                SetProperty(ref _erfassungsdatum, value);
            }
        }

        public string Benutzer
        {
            get
            {
                return _benutzer;
            }

            set
            {
                SetProperty(ref _benutzer, value);
            }
        }

        public DelegateCommand CmdDurchsuchen { get; }

        public DelegateCommand CmdSpeichern { get; }

        public DateTime? ValutaDatum
        {
            get
            {
                return _valutaDatum;
            }

            set
            {
                SetProperty(ref _valutaDatum, value);
            }
        }

        public bool IsRemoveFileEnabled
        {
            get
            {
                return _isRemoveFileEnabled;
            }

            set
            {
                SetProperty(ref _isRemoveFileEnabled, value);
            }
        }

        private void OnCmdDurchsuchen()
        {
            var openFileDialog = new OpenFileDialog();
            var result = openFileDialog.ShowDialog();

            if (result.GetValueOrDefault())
            {
                _filePath = openFileDialog.FileName;
            }
        }

        private void OnCmdSpeichern()
        {
            var outputFolderPath = ConfigurationManager.AppSettings["RepositoryDir"];
            outputFolderPath = CreateValutaFolderIfNotExists(outputFolderPath);

            var validationSuccessfull = ValidateDocument();
            if (validationSuccessfull == false)
            {
                MessageBox.Show("Bezeichnung, Valuta Datum und Typ müssen ausgewählt sein", "Validierung Fehlgeschlagen");
            }

            var guid = Guid.NewGuid();
            MetadataItem Item = new MetadataItem(_filePath, _bezeichnung, _valutaDatum.Value, _selectedTypItem, _erfassungsdatum, _benutzer, _isRemoveFileEnabled);
            DataToXml dataToXml = new DataToXml();
            dataToXml.MetadatenSchreiben(Item, guid, outputFolderPath);


            var CopyFileSucessfull = CopyFile(guid, outputFolderPath);
            if (Item.DateiAnschliessendLöschen == true && CopyFileSucessfull == true)
            {
                File.Delete(_filePath);
            }

            _navigateBack();
        }

        private string CreateValutaFolderIfNotExists(string outputFolderPath)
        {
            var valutaFolderPath = outputFolderPath + "/" + ValutaDatum.Value.Year;
            Directory.CreateDirectory(valutaFolderPath);
            return valutaFolderPath;
        }

        private bool CopyFile(Guid guid, string outputFolerPath)
        {
            try
            {
                var destinationPath = Path.Combine(outputFolerPath, $"{guid}_{Path.GetFileName(_filePath)}");
                File.Copy(_filePath, destinationPath);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        private bool ValidateDocument()
        {
            if (_bezeichnung == null)
            {
                return false;
            }
            else if (!_valutaDatum.HasValue)
            {
                return false;
            }
            else if (_selectedTypItem == null)
            {
                return false;
            }

            return true;

        }
    }
}