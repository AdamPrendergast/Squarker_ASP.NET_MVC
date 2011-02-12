using System.Web.Mvc;

namespace SquarkerApp.Controllers
{
	public abstract class RestfulController<TEntity, TKey> : Controller
	{
		// [HttpGet] Does not work. System.Web.Mvc v2.0.0.0 seems to be registered everywhere.
		// Will continue to look into a solution. 
		
		[AcceptVerbs(HttpVerbs.Get)]
	    public abstract ActionResult Index();
		
		[AcceptVerbs(HttpVerbs.Get)]
	    public abstract ActionResult New();
		
		[AcceptVerbs(HttpVerbs.Get)]
	    public abstract ActionResult Show(TKey id);
		
	    [AcceptVerbs(HttpVerbs.Post)]
	    public abstract ActionResult Create(TEntity entity);
		
		[AcceptVerbs(HttpVerbs.Get)]
	    public abstract ActionResult Edit(TKey id);
		
	    [AcceptVerbs(HttpVerbs.Put)]
	    public abstract ActionResult Update(TEntity entity);
		
	   	[AcceptVerbs(HttpVerbs.Delete)]
	    public abstract ActionResult Delete(TKey id);
	}
}

