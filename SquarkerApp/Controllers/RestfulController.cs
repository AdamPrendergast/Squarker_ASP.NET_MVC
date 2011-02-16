using System.Web.Mvc;

namespace SquarkerApp.Controllers
{
	public abstract class RestfulController<TEntity, TKey> : Controller
	{
		[HttpGet]
	    public abstract ActionResult Index();

	    [HttpGet]
		public abstract ActionResult New();
		
	    [HttpGet]
		public abstract ActionResult Show(TKey id);
		
	    [HttpPost]
		public abstract ActionResult Create(TEntity entity);
		
	    [HttpGet]
		public abstract ActionResult Edit(TKey id);
		
	    [HttpPut]
		public abstract ActionResult Update(TEntity entity);
		
	    [HttpDelete]
		public abstract ActionResult Delete(TKey id);
	}
}

