using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Actorss
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actors>()
                    {
                        new Actors()
                        {
                            fullName = "Actor 1",
                            bio = "This is the Bio of the first actor",
                            profilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Actors()
                        {
                            fullName = "Actor 2",
                            bio = "This is the Bio of the second actor",
                            profilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actors()
                        {
                            fullName = "Actor 3",
                            bio = "This is the Bio of the third actor",
                            profilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actors()
                        {
                            fullName = "Actor 4",
                            bio = "This is the Bio of the fourth actor",
                            profilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Actors()
                        {
                            fullName = "Actor 5",
                            bio = "This is the Bio of the fifth actor",
                            profilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }

                //Cinema
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinemas>()
                    {
                        new Cinemas()
                        {
                            name = "Cinema 1",
                            cinemaLogo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            description = "This is the description of the first cinema"
                        },
                        new Cinemas()
                        {
                            name = "Cinema 2",
                            cinemaLogo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            description = "This is the description of the second cinema"
                        },
                        new Cinemas()
                        {
                            name = "Cinema 3",
                            cinemaLogo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            description = "This is the description of the third cinema"
                        },
                        new Cinemas()
                        {
                            name = "Cinema 4",
                            cinemaLogo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            description = "This is the description of the fourth cinema"
                        },
                        new Cinemas()
                        {
                            name = "Cinema 5",
                            cinemaLogo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            description = "This is the description of the fifth cinema"
                        },
                    });
                    context.SaveChanges();
                }

                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producers>()
                    {
                        new Producers()
                        {
                            fullName = "Producer 1",
                            bio = "This is the Bio of the first Producer",
                            profilePictureURL = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new Producers()
                        {
                            fullName = "Producer 2",
                            bio = "This is the Bio of the second Producer",
                            profilePictureURL = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Producers()
                        {
                            fullName = "Producer 3",
                            bio = "This is the Bio of the third Producer",
                            profilePictureURL = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Producers()
                        {
                            fullName = "Producer 4",
                            bio = "This is the Bio of the fourth Producer",
                            profilePictureURL = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Producers()
                        {
                            fullName = "Producer 5",
                            bio = "This is the Bio of the fifth Producer",
                            profilePictureURL = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }

                //Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movies>()
                    {
                        new Movies()
                        {
                            name = "Life",
                            description = "This is the Life movie description",
                            price = 39.50,
                            imageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            startDate = DateTime.Now.AddDays(-10),
                            endDate = DateTime.Now.AddDays(10),
                            cinemaId = 3,
                            producerId = 3,
                            movieCategory = MovieCategory.Documentary
                        },
                        new Movies()
                        {
                            name = "The Shawshank Redemption",
                            description = "This is the Shawshank Redemption description",
                            price = 29.50,
                            imageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            startDate = DateTime.Now,
                            endDate = DateTime.Now.AddDays(3),
                            cinemaId = 1,
                            producerId = 1,
                            movieCategory = MovieCategory.Action
                        },
                        new Movies()
                        {
                            name = "Ghost",
                            description = "This is the Ghost movie description",
                            price = 39.50,
                            imageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            startDate = DateTime.Now,
                            endDate = DateTime.Now.AddDays(7),
                            cinemaId = 4,
                            producerId = 4,
                            movieCategory = MovieCategory.Horror
                        },
                        new Movies()
                        {
                            name = "Race",
                            description = "This is the Race movie description",
                            price = 39.50,
                            imageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            startDate = DateTime.Now.AddDays(-10),
                            endDate = DateTime.Now.AddDays(-5),
                            cinemaId = 1,
                            producerId = 2,
                            movieCategory = MovieCategory.Documentary
                        },
                        new Movies()
                        {
                            name = "Scoob",
                            description = "This is the Scoob movie description",
                            price = 39.50,
                            imageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            startDate = DateTime.Now.AddDays(-10),
                            endDate = DateTime.Now.AddDays(-2),
                            cinemaId = 1,
                            producerId = 3,
                            movieCategory = MovieCategory.Cartoon
                        },
                        new Movies()
                        {
                            name = "Cold Soles",
                            description = "This is the Cold Soles movie description",
                            price = 39.50,
                            imageURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            startDate = DateTime.Now.AddDays(3),
                            endDate = DateTime.Now.AddDays(20),
                            cinemaId = 1,
                            producerId = 5,
                            movieCategory = MovieCategory.Drama
                        }
                    });
                    context.SaveChanges();
                }

                //Actors & Movies
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actors_Movies>()
                    {
                        new Actors_Movies()
                        {
                            actorId = 1,
                            movieId = 1
                        },
                        new Actors_Movies()
                        {
                            actorId = 3,
                            movieId = 1
                        },

                         new Actors_Movies()
                        {
                            actorId = 1,
                            movieId = 2
                        },
                         new Actors_Movies()
                        {
                            actorId = 4,
                            movieId = 2
                        },

                        new Actors_Movies()
                        {
                            actorId = 1,
                            movieId = 3
                        },
                        new Actors_Movies()
                        {
                            actorId = 2,
                            movieId = 3
                        },
                        new Actors_Movies()
                        {
                            actorId = 5,
                            movieId = 3
                        },


                        new Actors_Movies()
                        {
                            actorId = 2,
                            movieId = 4
                        },
                        new Actors_Movies()
                        {
                            actorId = 3,
                            movieId = 4
                        },
                        new Actors_Movies()
                        {
                            actorId = 4,
                            movieId = 4
                        },


                        new Actors_Movies()
                        {
                            actorId = 2,
                            movieId = 5
                        },
                        new Actors_Movies()
                        {
                            actorId = 3,
                            movieId = 5
                        },
                        new Actors_Movies()
                        {
                            actorId = 4,
                            movieId = 5
                        },
                        new Actors_Movies()
                        {
                            actorId = 5,
                            movieId = 5
                        },
                        new Actors_Movies()
                        {
                            actorId = 3,
                            movieId = 6
                        },
                        new Actors_Movies()
                        {
                            actorId = 4,
                            movieId = 6
                        },
                        new Actors_Movies()
                        {
                            actorId = 5,
                            movieId = 6
                        },
                    });
                    context.SaveChanges();
                }
            }

        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles 
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "Admin@eTickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);

                if(adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        fullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "User@eTickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);

                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        fullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}