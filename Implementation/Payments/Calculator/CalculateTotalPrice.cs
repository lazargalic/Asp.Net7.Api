using Application;
using Application.Exceptions;
using Application.UseCases.Dto;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Payments.Calculator
{
    public class CalculateTotalPrice
    {
        public Asp2023DbContext Context { get; }
        public IApplicationUser User { get; }
        public CalculateTotalPrice(Asp2023DbContext context, IApplicationUser user)
        {
            Context = context;
            User = user;
        }

        public double CalculateArticleTotalPrice(CreatingArticle article)
        {
            var categoryDesignArticlePrice = Context.CategoryDesignArticles.Find(article.CategoryDesignArticleId);
            var categoryDimensionArticlePrice = Context.CategoryDimensions.Find(article.CategoryDimensionId);

            if (categoryDesignArticlePrice == null)
            {
                throw new EntityNotFoundException("categoryDesignArticle", article.CategoryDesignArticleId);
            }
            if (categoryDimensionArticlePrice == null)
            {
                throw new EntityNotFoundException("categoryDimension", article.CategoryDimensionId);
            }

            double total = categoryDimensionArticlePrice.Price + categoryDesignArticlePrice.Price;
            return total;
        }

        public double CalculateCommentTotalPrice(AddCommentUserDto comment)
        {
            var categoryDesignCommentPrice = Context.CategoryDesignArticles.Find(comment.CategoryCommentId);
            var categoryDimensionCommentPrice = Context.CategoryDimensions.Find(comment.CategoryDimensionId);

            if (categoryDesignCommentPrice == null)
            {
                throw new EntityNotFoundException("categoryComment(Design)", comment.CategoryCommentId);
            }
            if (categoryDimensionCommentPrice == null)
            {
                throw new EntityNotFoundException("categoryDimension", comment.CategoryDimensionId);
            }

            double total = categoryDesignCommentPrice.Price + categoryDimensionCommentPrice.Price;
            return total;
        }
    }
}
