using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoryRepository: BaseRepository<Catagory>
    {
        public override List<Catagory> List()
        {
            MemoryCache mChache = MemoryCache.Default;
            List<Catagory> news = new List<Catagory>();
            if (!mChache.Contains("catList"))
            {
                news = new NewsEntities1().Set<Catagory>().ToList();
                mChache.Add("catList", news, DateTimeOffset.Now.AddSeconds(30));
            }
            else
            {
                news = (List<Catagory>)mChache.Get("catList");
            }
            return news;
        }
    }
}
