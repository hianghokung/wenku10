﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

using Net.Astropenguin.DataModel;
using Net.Astropenguin.IO;
using Net.Astropenguin.Logging;

using libtaotu.Controls;

namespace wenku8.Model.Section
{
    using Book;
    using Loaders;

    sealed class ZoneSpider : ActiveData
    {
        public static readonly string ID = typeof( ZoneSpider ).Name;

        public Observables<BookItem, BookItem> Data { get; private set; }

        public async void OpenFile()
        {
            try
            {
                IStorageFile ISF = await AppStorage.OpenFileAsync( ".xml" );
                if ( ISF == null ) return;

                XParameter Param = new XRegistry( await ISF.ReadString(), null, false ).Parameter( "Procedures" );
                ProcManager PM = new ProcManager( Param );

                ZSFeedbackLoader<BookItem> ZSF = new ZSFeedbackLoader<BookItem>( PM.CreateSpider() );
                Data = new Observables<BookItem, BookItem>( await ZSF.NextPage() );
                Data.ConnectLoader( ZSF );

                NotifyChanged( "Data" );
            }
            catch( Exception ex )
            {
                Logger.Log( ID, ex.Message, LogType.ERROR );
            }
        }

    }
}