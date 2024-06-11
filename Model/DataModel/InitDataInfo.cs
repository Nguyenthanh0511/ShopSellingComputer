using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceComputer.Model.DataModel
{
    public class InitDataInfo : DbContext
    {
        private readonly IServiceProvider _serviceProvider;
        public InitDataInfo(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }
        public async Task Seed()
        {
            using (var scoped = _serviceProvider.CreateScope())
            {
                var context = scoped.ServiceProvider.GetRequiredService<DBServiceComputerContext>();

                if (!context.categories.Any())
                {
                    var categories = new List<Category>
                {
                    new Category { Name = "Computer out-date" },
                    new Category { Name = "Computer repair" },
                    new Category { Name = "Computer new" },
                    new Category{Name = "White Device"}
                };

                    await context.categories.AddRangeAsync(categories);
                    await context.SaveChangesAsync();
                }

                if (!context.Products.Any())
                {
                    var products = new List<Product>
                    {
                        new Product
                        {
                            Name = "Lorem Ipsum",
                            ImageUrl = "https://tse2.mm.bing.net/th?id=OIP.3KYzfrdZkrTfGKkel4nA5wHaE8&pid=Api&P=0&h=220",
                            CategoryId = 1,
                            Description = "#\r\nData recovery\r\nLorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
                        },
                        new Product
                        {
                             Name = "Exerci tation",
                            ImageUrl = "https://tse3.mm.bing.net/th?id=OIP.8BGowKEmswAiORMkfEiSIQHaHa&pid=Api&P=0&h=220",
                            CategoryId = 1,
                            Description = "#\r\nData recovery\r\nLorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
                        },
                        new Product
                        {
                             Name = "Vintage",
                            ImageUrl = "https://tse2.mm.bing.net/th?id=OIP.r_qnyOWgY9iJejjrfOp5pwAAAA&pid=Api&P=0&h=220",
                            CategoryId = 1,
                            Description = "#\r\nData recovery\r\nLorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
                        },
                        new Product
                        {
                             Name = "Norton Internet Security",
                             ImageUrl = "https://tse3.mm.bing.net/th?id=OIP.9_hX-3_p1A65iIWWlDwyCwAAAA&pid=Api&P=0&h=220",
                             CategoryId = 4,
                             Description = "#\r\nData recovery\r\nLorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
                        },
                        new Product
                        {
                             Name = "Kaspersky Internet Security",
                             ImageUrl = "https://sp.yimg.com/ib/th?id=OPHS.mIkXoraReNFd0g474C474&o=5&pid=21.1&w=160&h=105",
                             CategoryId = 4,
                             Description = "#\r\nData recovery\r\nLorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
                        },
                    };
                    await context.Products.AddRangeAsync(products);
                    await context.SaveChangesAsync();
                }
                if (!context.Images.Any() ){
                    var images = new List<Image>()
                    {
                        new Image
                        {
                            Url = "https://tse2.mm.bing.net/th?id=OIP.r_qnyOWgY9iJejjrfOp5pwAAAA&pid=Api&P=0&h=220"
                            ,ProductId = 1
                        },
                         new Image
                        {
                            Url = "https://th.bing.com/th/id/OIP.qwnpRJPm7Ukk3DO6bX2lgQHaHa?w=177&h=180&c=7&r=0&o=5&dpr=1.3&pid=1.7"
                            ,ProductId = 1
                        },
                        new Image
                        {
                            Url="https://sp.yimg.com/ib/th?id=OPHS.5hnJEwhFHIemZA474C474&o=5&pid=21.1&w=160&h=105",
                            ProductId = 5
                        }
                        ,new Image
                        {
                            Url="https://tse1.mm.bing.net/th?id=OIP.paReeT4_gz89UkHNrj71sQHaD_&pid=Api&P=0&h=220",
                            ProductId = 5
                        }
                    };
                }
            }
        }
    }
}
