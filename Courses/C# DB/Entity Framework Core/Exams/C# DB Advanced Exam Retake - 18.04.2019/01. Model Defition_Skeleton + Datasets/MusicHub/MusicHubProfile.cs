namespace MusicHub
{
    using AutoMapper;
    using MusicHub.Data.Models;
    using MusicHub.DataProcessor.ImportDtos;
    using System;
    using System.Globalization;

    public class MusicHubProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public MusicHubProfile()
        {
            this.CreateMap<ImportWritersDtoJson, Writer>();

            this.CreateMap<ImportAlbumDto, Album>()
               .ForMember(x => x.ReleaseDate, y => y.MapFrom(
                   x => DateTime.ParseExact(x.ReleaseDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture)));
            
            this.CreateMap<ImportProducersAlbumsDtoJson, Producer>();

            //this.CreateMap<XmlImportSong, Song>();

            //this.CreateMap<XmlImportPerformer, Performer>();

           // this.CreateMap<Song, JsonExportSong>();

            //this.CreateMap<Album, JsonExportAlbum>();

            //this.CreateMap<Song, XmlExportSong>();
        }
    }
}
