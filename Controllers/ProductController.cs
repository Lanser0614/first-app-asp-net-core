using System.Collections;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication6.DbContext;

namespace WebApplication6.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly DbDatabaseContext _context;
    public ProductController(DbDatabaseContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Route("send")]
    public async Task<IActionResult> send()
    {
       var user = new Models.User
        {
            Name = "sa",
            Email = "sd",
            Password = "asdsds"
        };
       int idBefored = Thread.CurrentThread.ManagedThreadId;
        await _context.users.AddAsync(user);
        int idBefore = Thread.CurrentThread.ManagedThreadId;
        await _context.SaveChangesAsync();
        int idAfter = Thread.CurrentThread.ManagedThreadId;
        var list = new ArrayList();
        list.Add(idBefore);
        list.Add(idAfter);
        list.Add(idBefored);
       
        return Ok(list);
    }
    
    [HttpGet]
    [Route("login")]
    public String Login()
    {
        //Fire - and - Forget Job - this job is executed only once
        var jobId = BackgroundJob.Enqueue(() => Console.WriteLine("Welcome to Shopping World!"));

        return $"Job ID: {jobId}. Welcome mail sent to the user!";
    }

    [HttpGet]
    [Route("productcheckout")]
    public String CheckoutProduct()
    {
        //Delayed Job - this job executed only once but not immedietly after some time.
        var jobId = BackgroundJob.Schedule(() => Console.WriteLine("You checkout new product into your checklist!"),TimeSpan.FromSeconds(20));

        return $"Job ID: {jobId}. You added one product into your checklist successfully!";
    }

    [HttpGet]
    [Route("productpayment")]
    public String ProductPayment()
    {
        //Fire and Forget Job - this job is executed only once
        var parentjobId = BackgroundJob.Enqueue(() => Console.WriteLine("You have done your payment suceessfully!"));

        //Continuations Job - this job executed when its parent job is executed.
        BackgroundJob.ContinueJobWith(parentjobId, () => Console.WriteLine("Product receipt sent!"));

        return "You have done payment and receipt sent on your mail id!";
    }

    [HttpGet]
    [Route("dailyoffers")]
    public String DailyOffers()
    {
        //Recurring Job - this job is executed many times on the specified cron schedule
        RecurringJob.AddOrUpdate(() => Console.WriteLine("Sent similar product offer and suuggestions"), Cron.MinuteInterval(1));

        return "offer sent!";
    }
}