using AutoMapper;
using BenchmarkDotNet.Attributes;
using Mapster;
using ObjectsMapperBenchmark.Dto;
using ObjectsMapperBenchmark.Entities;
using System.IO;
using System.Linq;

namespace ObjectsMapperBenchmark
{
    [InProcess]
    public class BenchmarkContainer
    {
        private readonly SpotifyAlbumDto _spotifyAlbumDto = null;
        private readonly IMapper _autoMapper;
        public BenchmarkContainer()
        {
            var json = File.ReadAllText("spotifyAlbum.json");
            _spotifyAlbumDto = SpotifyAlbumDto.FromJson(json);

            //Automapper Configuration 
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SpotifyAlbumDto, SpotifyAlbum>();
                cfg.CreateMap<CopyrightDto, Copyright>();
                cfg.CreateMap<ArtistDto, Artist>();
                cfg.CreateMap<ExternalIdsDto, ExternalIds>();
                cfg.CreateMap<ExternalUrlsDto, ExternalUrls>();
                cfg.CreateMap<TracksDto, Tracks>();
                cfg.CreateMap<ImageDto, Image>();
                cfg.CreateMap<ItemDto, Item>();
                cfg.CreateMap<SpotifyAlbum, SpotifyAlbumDto>();
                cfg.CreateMap<Copyright, CopyrightDto>();
                cfg.CreateMap<Artist, ArtistDto>();
                cfg.CreateMap<ExternalIds, ExternalIdsDto>();
                cfg.CreateMap<ExternalUrls, ExternalUrlsDto>();
                cfg.CreateMap<Tracks, TracksDto>();
                cfg.CreateMap<Image, ImageDto>();
                cfg.CreateMap<Item, ItemDto>();
            });
            _autoMapper = mapperConfig.CreateMapper();

            //TinyMapper Configuration 
            Nelibur.ObjectMapper.TinyMapper.Bind<SpotifyAlbumDto, SpotifyAlbum>();
            Nelibur.ObjectMapper.TinyMapper.Bind<CopyrightDto, Copyright>();
            Nelibur.ObjectMapper.TinyMapper.Bind<ArtistDto, Artist>();
            Nelibur.ObjectMapper.TinyMapper.Bind<ExternalIdsDto, ExternalIds>();
            Nelibur.ObjectMapper.TinyMapper.Bind<ExternalUrlsDto, ExternalUrls>();
            Nelibur.ObjectMapper.TinyMapper.Bind<TracksDto, Tracks>();
            Nelibur.ObjectMapper.TinyMapper.Bind<ImageDto, Image>();
            Nelibur.ObjectMapper.TinyMapper.Bind<ItemDto, Item>();
            Nelibur.ObjectMapper.TinyMapper.Bind<SpotifyAlbum, SpotifyAlbumDto>();
            Nelibur.ObjectMapper.TinyMapper.Bind<Copyright, CopyrightDto>();
            Nelibur.ObjectMapper.TinyMapper.Bind<Artist, ArtistDto>();
            Nelibur.ObjectMapper.TinyMapper.Bind<ExternalIds, ExternalIdsDto>();
            Nelibur.ObjectMapper.TinyMapper.Bind<ExternalUrls, ExternalUrlsDto>();
            Nelibur.ObjectMapper.TinyMapper.Bind<Tracks, TracksDto>();
            Nelibur.ObjectMapper.TinyMapper.Bind<Image, ImageDto>();
            Nelibur.ObjectMapper.TinyMapper.Bind<Item, ItemDto>();

            //ExpressMapper Configuration 
            global::ExpressMapper.Mapper.Register<SpotifyAlbumDto, SpotifyAlbum>();
            global::ExpressMapper.Mapper.Register<CopyrightDto, Copyright>();
            global::ExpressMapper.Mapper.Register<ArtistDto, Artist>();
            global::ExpressMapper.Mapper.Register<ExternalIdsDto, ExternalIds>();
            global::ExpressMapper.Mapper.Register<ExternalUrlsDto, ExternalUrls>();
            global::ExpressMapper.Mapper.Register<TracksDto, Tracks>();
            global::ExpressMapper.Mapper.Register<ImageDto, Image>();
            global::ExpressMapper.Mapper.Register<ItemDto, Item>();
            global::ExpressMapper.Mapper.Register<SpotifyAlbum, SpotifyAlbumDto>();
            global::ExpressMapper.Mapper.Register<Copyright, CopyrightDto>();
            global::ExpressMapper.Mapper.Register<Artist, ArtistDto>();
            global::ExpressMapper.Mapper.Register<ExternalIds, ExternalIdsDto>();
            global::ExpressMapper.Mapper.Register<ExternalUrls, ExternalUrlsDto>();
            global::ExpressMapper.Mapper.Register<Tracks, TracksDto>();
            global::ExpressMapper.Mapper.Register<Image, ImageDto>();
            global::ExpressMapper.Mapper.Register<Item, ItemDto>();

            //UltraMapper don't need configuration, but that's ok
            var ultraConfig = new UltraMapper.Configuration(config =>
            {
                config.MapTypes<SpotifyAlbumDto, SpotifyAlbum>();
                config.MapTypes<CopyrightDto, Copyright>();
                config.MapTypes<ArtistDto, Artist>();
                config.MapTypes<ExternalIdsDto, ExternalIds>();
                config.MapTypes<ExternalUrlsDto, ExternalUrls>();
                config.MapTypes<TracksDto, Tracks>();
                config.MapTypes<ImageDto, Image>();
                config.MapTypes<ItemDto, Item>();
                config.MapTypes<SpotifyAlbum, SpotifyAlbumDto>();
                config.MapTypes<Copyright, CopyrightDto>();
                config.MapTypes<Artist, ArtistDto>();
                config.MapTypes<ExternalIds, ExternalIdsDto>();
                config.MapTypes<ExternalUrls, ExternalUrlsDto>();
                config.MapTypes<Tracks, TracksDto>();
                config.MapTypes<Image, ImageDto>();
                config.MapTypes<Item, ItemDto>();
            });
            //Mapster don't need configuration
            //AgileMapper don't need configuration
        }

        [Benchmark]
        public SpotifyAlbum AgileMapper()
        {
            var spotifyalbum = AgileObjects.AgileMapper.Mapper.Map(_spotifyAlbumDto).ToANew<SpotifyAlbum>();
            return spotifyalbum;
        }

        [Benchmark]
        public SpotifyAlbum TinyMapper()
        {
            var spotifyAlbum = Nelibur.ObjectMapper.TinyMapper.Map<SpotifyAlbum>(_spotifyAlbumDto);
            return spotifyAlbum;
        }

        [Benchmark]
        public SpotifyAlbum ExpressMapper()
        {
            var spotifyalbum = global::ExpressMapper.Mapper.Map<SpotifyAlbumDto, SpotifyAlbum>(_spotifyAlbumDto);
            return spotifyalbum;
        }

        [Benchmark]
        public SpotifyAlbum AutoMapper()
        {
            var spotifyalbum = _autoMapper.Map<SpotifyAlbum>(_spotifyAlbumDto);
            return spotifyalbum;
        }

        [Benchmark]
        public SpotifyAlbum ManualMapping()
        {
            //Generated by MappingGenerator
            var spotifyalbum = _spotifyAlbumDto.Map();
            return spotifyalbum;
        }

        [Benchmark]
        public SpotifyAlbum Mapster()
        {
            var spotifyalbum = _spotifyAlbumDto.Adapt<SpotifyAlbum>();
            return spotifyalbum;
        }

        [Benchmark]
        public SpotifyAlbum UltraMapper()
        {
            var mapper = new UltraMapper.Mapper();
            var spotifyalbum = mapper.Map<SpotifyAlbumDto, SpotifyAlbum>(_spotifyAlbumDto);
            return spotifyalbum;
        }
    }

    public static class Mapper
    {
        public static SpotifyAlbum Map(this SpotifyAlbumDto spotifyAlbumDto)
        {
            return new SpotifyAlbum()
            {
                AlbumType = spotifyAlbumDto.AlbumType,
                Artists = spotifyAlbumDto.Artists.Select(spotifyAlbumDtoArtist => new Artist()
                {
                    ExternalUrls = new ExternalUrls()
                    {
                        Spotify = spotifyAlbumDtoArtist.ExternalUrls.Spotify
                    },
                    Href = spotifyAlbumDtoArtist.Href,
                    Id = spotifyAlbumDtoArtist.Id,
                    Name = spotifyAlbumDtoArtist.Name,
                    Type = spotifyAlbumDtoArtist.Type,
                    Uri = spotifyAlbumDtoArtist.Uri
                }).ToArray(),
                AvailableMarkets = spotifyAlbumDto.AvailableMarkets,
                Copyrights = spotifyAlbumDto.Copyrights.Select(spotifyAlbumDtoCopyright => new Copyright()
                {
                    Text = spotifyAlbumDtoCopyright.Text,
                    Type = spotifyAlbumDtoCopyright.Type
                }).ToArray(),
                ExternalIds = new ExternalIds()
                {
                    Upc = spotifyAlbumDto.ExternalIds.Upc
                },
                ExternalUrls = new ExternalUrls()
                {
                    Spotify = spotifyAlbumDto.ExternalUrls.Spotify
                },
                Genres = spotifyAlbumDto.Genres,
                Href = spotifyAlbumDto.Href,
                Id = spotifyAlbumDto.Id,
                Images = spotifyAlbumDto.Images.Select(spotifyAlbumDtoImage => new Image()
                {
                    Height = spotifyAlbumDtoImage.Height,
                    Url = spotifyAlbumDtoImage.Url,
                    Width = spotifyAlbumDtoImage.Width
                }).ToArray(),
                Name = spotifyAlbumDto.Name,
                Popularity = spotifyAlbumDto.Popularity,
                ReleaseDate = spotifyAlbumDto.ReleaseDate,
                ReleaseDatePrecision = spotifyAlbumDto.ReleaseDatePrecision,
                Tracks = new Tracks()
                {
                    Href = spotifyAlbumDto.Tracks.Href,
                    Items = spotifyAlbumDto.Tracks.Items.Select(spotifyAlbumDtoTracksItem => new Item()
                    {
                        Artists = spotifyAlbumDtoTracksItem.Artists.Select(spotifyAlbumDtoTracksItemArtist => new Artist()
                        {
                            ExternalUrls = new ExternalUrls()
                            {
                                Spotify = spotifyAlbumDtoTracksItemArtist.ExternalUrls.Spotify
                            },
                            Href = spotifyAlbumDtoTracksItemArtist.Href,
                            Id = spotifyAlbumDtoTracksItemArtist.Id,
                            Name = spotifyAlbumDtoTracksItemArtist.Name,
                            Type = spotifyAlbumDtoTracksItemArtist.Type,
                            Uri = spotifyAlbumDtoTracksItemArtist.Uri
                        }).ToArray(),
                        AvailableMarkets = spotifyAlbumDtoTracksItem.AvailableMarkets,
                        DiscNumber = spotifyAlbumDtoTracksItem.DiscNumber,
                        DurationMs = spotifyAlbumDtoTracksItem.DurationMs,
                        Explicit = spotifyAlbumDtoTracksItem.Explicit,
                        ExternalUrls = new ExternalUrls()
                        {
                            Spotify = spotifyAlbumDtoTracksItem.ExternalUrls.Spotify
                        },
                        Href = spotifyAlbumDtoTracksItem.Href,
                        Id = spotifyAlbumDtoTracksItem.Id,
                        Name = spotifyAlbumDtoTracksItem.Name,
                        PreviewUrl = spotifyAlbumDtoTracksItem.PreviewUrl,
                        TrackNumber = spotifyAlbumDtoTracksItem.TrackNumber,
                        Type = spotifyAlbumDtoTracksItem.Type,
                        Uri = spotifyAlbumDtoTracksItem.Uri
                    }).ToArray(),
                    Limit = spotifyAlbumDto.Tracks.Limit,
                    Next = spotifyAlbumDto.Tracks.Next,
                    Offset = spotifyAlbumDto.Tracks.Offset,
                    Previous = spotifyAlbumDto.Tracks.Previous,
                    Total = spotifyAlbumDto.Tracks.Total
                },
                Type = spotifyAlbumDto.Type,
                Uri = spotifyAlbumDto.Uri
            };
        }
    }
}
