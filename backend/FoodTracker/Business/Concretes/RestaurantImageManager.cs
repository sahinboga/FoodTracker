using Business.Abstracts;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelpers;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Business.Concretes
{
	public class RestaurantImageManager : IRestaurantImageService
	{
		IRestaurantImageDal _restaurantImageDal;

		public RestaurantImageManager(IRestaurantImageDal restaurantImageDal)
		{
			_restaurantImageDal = restaurantImageDal;
		}

		public IResult Add(RestaurantImage restaurantImage)
		{
			_restaurantImageDal.Add(restaurantImage);
			return new SuccessResult(Messages.ImageAdded);
		}

		public IResult Delete(RestaurantImage restaurantImage)
		{
			ImageFileHelper.Delete(restaurantImage.ImagePath);

			_restaurantImageDal.Delete(restaurantImage);
			return  new SuccessResult(Messages.ImageDeleted);
		}

		public IDataResult<List<RestaurantImage>> GetAll()
		{
			return new SuccessDataResult<List<RestaurantImage>>(_restaurantImageDal.GetAll(),Messages.Listed);
		}

		public IDataResult<RestaurantImage> GetById(int imageId)
		{
			var image=_restaurantImageDal.GetById(img=>img.Id==imageId);
			return new SuccessDataResult<RestaurantImage>(image);
		}

		public IDataResult<RestaurantImage> GetFirstOrDefaultByCarId(int restaurantId)
		{
			RestaurantImage restaurantImage = _restaurantImageDal.GetById(r => r.RestaurantId == restaurantId);

			if (restaurantImage == null)
			{
				restaurantImage = new RestaurantImage
				{
					Id = 0,
					RestaurantId = restaurantId,
					ImagePath = this.GetDefaultRestaurantImagePath(),
				};
			}
			return new SuccessDataResult<RestaurantImage>(restaurantImage);
		}

		public IDataResult<List<RestaurantImage>> GetRestaurantImagesByRestaurantId(int restaurantId)
		{
			List<RestaurantImage> restaurantImages = _restaurantImageDal.GetAll(r => r.RestaurantId == restaurantId);
			if (restaurantImages.Count == 0)
			{
				restaurantImages.Add(new RestaurantImage
				{
					Id = 0,
					RestaurantId=restaurantId,
					ImagePath = this.GetDefaultRestaurantImagePath(),
				});
			}
			return new SuccessDataResult<List<RestaurantImage>>(restaurantImages);
		}

		public IResult Update(RestaurantImage restaurantImage)
		{
			_restaurantImageDal.Update(restaurantImage);
			return new SuccessResult(Messages.ImageUpdated);
		}

		public IResult UploadRestaurantImage(IFormFile imageFile, RestaurantImage restaurantImage)
		{
			var result = BusinessRules.Run(CheckIfImageLimitExceded(restaurantImage.RestaurantId));
			if (result != null)
			{
				return result;
			}


			string filePath = ImageFileHelper.Upload(imageFile);
			restaurantImage.ImagePath = filePath;

			return this.Add(restaurantImage);
		}

		private IResult CheckIfImageLimitExceded(int restaurantId)
		{
			var result = _restaurantImageDal.GetAll(r => r.RestaurantId == restaurantId).Count;
			if (result >= 3)
			{
				return new ErrorResult(Messages.ImageLimitExceded);
			}
			return new SuccessResult();
		}

		private string GetDefaultRestaurantImagePath()
		{
			return ImageFileHelper.GetDefaultRestaurantImagePath() + "/" + ImagePaths.defaultRestaurantImageName;
		}
	}
}
