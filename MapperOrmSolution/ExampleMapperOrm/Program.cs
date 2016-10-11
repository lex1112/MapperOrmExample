using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MapperOrm.Repository;

namespace ExampleMapperOrm
{
    class Program
    {
        static void Main(string[] args)
        {
            var events = new ManualResetEvent[5];
            for (var i = 0; i <= events.Length - 1; i++)
            {
                events[i] = new ManualResetEvent(false);
            }
            var t = new Thread(() =>
                {
                    Thread.Sleep(2000);
                    Do();

                    events[0].Reset();
                });

            var t1 = new Thread(() =>
            {
                Thread.Sleep(500);
                Do();
                events[1].Reset();
            });
            var t2 = new Thread(() =>
            {
                Thread.Sleep(10000);
                Do();
                events[2].Reset();
            });
            var t3 = new Thread(() =>
            {
                Thread.Sleep(3000);
                Do();
                events[3].Reset();
            });
            var t4 = new Thread(() =>
            {
                Thread.Sleep(1000);
                Do();
                events[4].Reset();
            });

            t.Start();
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();

            WaitHandle.WaitAll(events);

            Console.ReadKey();
            //  Do();
        }

        private static void Do()
        {
            var uow = new UnitOfWork();

            using (UnitOfWorkManager.Create(uow))
            {
                var repo1 = new FurnitureRepository();


                var repo = new PictureRepository();
                //    var repo1 = new FurnitureRepository();


                var d = repo1.GetByColumnName(
                    new Dictionary<string, object>
                        {
                            {
                                "RoomId", 3
                            },

                            {
                                "Types", 2
                            }
                        }
                    );
                foreach (var f in d)
                {
                    repo1.Remove(f);
                }


                var e = repo.GetByColumnName(new Dictionary<string, object>
                    {
                        {
                            "Src", "трамп победит!"
                        },

                        {
                            "UserProfileId", 7
                        }
                    });

                foreach (var p in e)
                {
                    p.Src = "yyyyyy" + Thread.CurrentThread.ManagedThreadId;
                }


                //for (var i = 0; i <= 10; i++)
                //{
                //    repo1.Add(new Furniture
                //        {
                //            CreateDate = DateTime.UtcNow,
                //            Name = "новая блять запись" + i,
                //            RoomId = 3,
                //            Types = 2
                //        });
                //}

                for (var i = 0; i <= 3; i++)
                {
                    repo1.Add(new Furniture
                        {
                            CreateDate = DateTime.UtcNow,
                            Name = "новая блять запись" + Thread.CurrentThread.ManagedThreadId,
                            RoomId = 3,
                            Types = 2
                        });
                }


                //       list.Description = "888";
                //   f.Name = "хуй";

                uow.Commit();
            }
        }
    }
}
