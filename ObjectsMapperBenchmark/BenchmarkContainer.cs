﻿using AutoMapper;
using BenchmarkDotNet.Attributes;
using Mapster;
using Nelibur.ObjectMapper;
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
            TinyMapper.Bind<SpotifyAlbumDto, SpotifyAlbum>();
            TinyMapper.Bind<CopyrightDto, Copyright>();
            TinyMapper.Bind<ArtistDto, Artist>();
            TinyMapper.Bind<ExternalIdsDto, ExternalIds>();
            TinyMapper.Bind<ExternalUrlsDto, ExternalUrls>();
            TinyMapper.Bind<TracksDto, Tracks>();
            TinyMapper.Bind<ImageDto, Image>();
            TinyMapper.Bind<ItemDto, Item>();
            TinyMapper.Bind<SpotifyAlbum, SpotifyAlbumDto>();
            TinyMapper.Bind<Copyright, CopyrightDto>();
            TinyMapper.Bind<Artist, ArtistDto>();
            TinyMapper.Bind<ExternalIds, ExternalIdsDto>();
            TinyMapper.Bind<ExternalUrls, ExternalUrlsDto>();
            TinyMapper.Bind<Tracks, TracksDto>();
            TinyMapper.Bind<Image, ImageDto>();
            TinyMapper.Bind<Item, ItemDto>();

            //ExpressMapper Configuration 
            ExpressMapper.Mapper.Register<SpotifyAlbumDto, SpotifyAlbum>();
            ExpressMapper.Mapper.Register<CopyrightDto, Copyright>();
            ExpressMapper.Mapper.Register<ArtistDto, Artist>();
            ExpressMapper.Mapper.Register<ExternalIdsDto, ExternalIds>();
            ExpressMapper.Mapper.Register<ExternalUrlsDto, ExternalUrls>();
            ExpressMapper.Mapper.Register<TracksDto, Tracks>();
            ExpressMapper.Mapper.Register<ImageDto, Image>();
            ExpressMapper.Mapper.Register<ItemDto, Item>();
            ExpressMapper.Mapper.Register<SpotifyAlbum, SpotifyAlbumDto>();
            ExpressMapper.Mapper.Register<Copyright, CopyrightDto>();
            ExpressMapper.Mapper.Register<Artist, ArtistDto>();
            ExpressMapper.Mapper.Register<ExternalIds, ExternalIdsDto>();
            ExpressMapper.Mapper.Register<ExternalUrls, ExternalUrlsDto>();
            ExpressMapper.Mapper.Register<Tracks, TracksDto>();
            ExpressMapper.Mapper.Register<Image, ImageDto>();
            ExpressMapper.Mapper.Register<Item, ItemDto>();

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
        public SpotifyAlbum MapWithAgileMapper()
        {
            var spotifyalbum = AgileObjects.AgileMapper.Mapper.Map(_spotifyAlbumDto).ToANew<SpotifyAlbum>();
            return spotifyalbum;
        }

        [Benchmark]
        public SpotifyAlbum MapWithTinyMapper()
        {
            var spotifyAlbum = TinyMapper.Map<SpotifyAlbum>(_spotifyAlbumDto);
            return spotifyAlbum;
        }

        [Benchmark]
        public SpotifyAlbum MapWithExpressMapper()
        {
            var spotifyalbum = ExpressMapper.Mapper.Map<SpotifyAlbumDto, SpotifyAlbum>(_spotifyAlbumDto);
            return spotifyalbum;
        }

        [Benchmark]
        public SpotifyAlbum MapWithAutoMapper()
        {
            var spotifyalbum = _autoMapper.Map<SpotifyAlbum>(_spotifyAlbumDto);
            return spotifyalbum;
        }

        [Benchmark]
        public SpotifyAlbum MapWithManualMapping()
        {
            //Generated by MappingGenerator
            var spotifyalbum = _spotifyAlbumDto.Map();
            return spotifyalbum;
        }

        [Benchmark]
        public SpotifyAlbum MapWithMapster()
        {
            var spotifyalbum = _spotifyAlbumDto.Adapt<SpotifyAlbum>();
            return spotifyalbum;
        }

        [Benchmark]
        public SpotifyAlbum MapWithUltraMapper()
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
