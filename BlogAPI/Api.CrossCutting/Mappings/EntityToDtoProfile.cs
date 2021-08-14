using Api.Domain.Dtos;
using Api.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {

        public EntityToDtoProfile()
        {
            CreateMap<UserDto, UserEntity>().ReverseMap();
            CreateMap<UserDtoCreate, UserEntity>().ReverseMap();

            CreateMap<AddressDto, AddressEntity>().ReverseMap();
            CreateMap<AddressDtoCreate, AddressEntity>().ReverseMap();

            CreateMap<GeoDto, GeoEntity>().ReverseMap();
            CreateMap<GeoDtoCreate, GeoEntity>().ReverseMap();

            CreateMap<CompanyDto, CompanyEntity>().ReverseMap();
            CreateMap<CompanyDtoCreate, CompanyEntity>().ReverseMap();

            CreateMap<AlbumDto, AlbumEntity>().ReverseMap();
            CreateMap<AlbumDtoCreate, AlbumEntity>().ReverseMap();

            CreateMap<BlogPostDto, BlogPostEntity>().ReverseMap();
            CreateMap<BlogPostDtoCreate, BlogPostEntity>().ReverseMap();

            CreateMap<CommentDto, CommentEntity>().ReverseMap();
            CreateMap<CommentDtoCreate, CommentEntity>().ReverseMap();

            CreateMap<PhotoDto, PhotoEntity>().ReverseMap();
            CreateMap<PhotoDtoCreate, PhotoEntity>().ReverseMap();

        }
    }
}
