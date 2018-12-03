---
title: Austin Bergman
layout: default
---

## Notes
YOUR WEB-APP AND DATABASE ARE ALREADY MADE ON THE CLOUD

### STEPS 
1. Make your database ERD then the database
2. create a new item in your models class, then from there select "Code first.."
3. After your models and datacontext file are created, move your datacontext to a new foulder. (DAL)
4. BUILD YOU SOULTION
5. generate your controllers. If one needs CRUD then select build with entity frameworks
6. If you need to use ajax, remember your your logic should be handled in the contoller. use the controller to make what ever object you need to pass into ajax. (USE THE LINQ QUERY HERE)
7. if you are making you javascript  you must havve your JsonResult built in you contoller first, then use AJAX to specify wich method to use in the controller.
8. its ok to write your javascript in the htmll file, (It makes using IDs easier since you can jsut use razor)
9.  Refer to HW9 for cloud deployment



## Shell code 


### Javascript with AJAX
```js
// THIS IS FOR MANUEL CALLS FROM HTML (button onclick ="ajax_call") 
     function ajax_call(id) {

            $.ajax({
                type: 'GET',
                dataType: 'json',
                url: 'CONTROLLER AND METHOD PATH HERE' + id,
                data: { id: id },
                success: displayResults,
                error: errorOnAjax
            });
        }
        function displayResults(data) {
            $('#output').find('tbody').empty();
            data.forEach(function(item) {
                $('#output').find('tbody').append("<tr><td>"+item["OBJECTS OF YOUR LINQ"]+"</td><td>"+item["OBJECTS OF YOUR LINQ"]+"</td></tr>");
            });
            console.log(data);
        };
        function errorOnAjax() {
            console.log("Ajax Error");
        };


// THIS IS FOR NON MANUAL EVENT LISTENERS (USING RAZOR)
  function ajax_call() {
            var id = @Model.ItemID;
            $.ajax({
                type: 'GET',
                dataType: 'json',
                url: '/Items/BidResult/' + id,
                data: { id: id },
                success: displayResults,
                error: errorOnAjax
            });
        }
        var interval = 1000 * 5; // where X is your timer interval in X seconds
        window.setInterval(ajax_call(), interval);

        function displayResults(data) {
            data.forEach(function(item) {
                $('#allBids').find('tbody').append("<tr><td>"+item["OBJECT OF YOUR LINQ"]+"</td><td>"+item["OBJECT OF YOUR LINQ"]+"</td></tr>");
            });
            console.log(data);
        };
        function errorOnAjax() {
            console.log("Ajax Error");
        };


```



### Controller with a json action method 

```csharp
// The rest will be scaffolded so you will ahve to make edits from there
 public JsonResult BidResult(int? id)
        {
            var bids = db.Items.Where(i => i.ItemID == id).Select(b => b.Bids).FirstOrDefault()
                .Select(b => new { b.Price, b.Buyer.Buyername }).OrderByDescending(b => b.Price).ToList();


            return Json(bids, JsonRequestBehavior.AllowGet);
        }


```


DONT FORGET TO USE THE WEB CONSOLE WHEN YOU ARE DEBUGGING JAVASCRIPT


## Handle your exceptions and limits in the controller 

For example here is the hanleing for the Edit button in Art

```csharp

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ARTISTID,ARTISTNAME,ARTISTDOB,BIRTHCITY")] Artist artist)
        {
            if (artist.ARTISTNAME.Length > 50)
            {
                TempData["testmsg"] = "<script>alert('The name cannot be more than 50 characters!');</script>";
                return RedirectToAction("Edit");
            }

            string[] dob = artist.ARTISTDOB.Split('/');

            int month = Int32.Parse(dob[0]);
            int day = Int32.Parse(dob[1]);
            int year = Int32.Parse(dob[2]);


            int mm = DateTime.Now.Month;
            int dd = DateTime.Now.Day;
            int yyyy = DateTime.Now.Year;


            if (year > yyyy)
            {
                TempData["testmsg"] = "<script>alert('Incorrect Birthday');</script>";
                return RedirectToAction("Edit");
            }
            else if (year == yyyy && month > mm)
            {
                TempData["testmsg"] = "<script>alert('Incorrect Birthday');</script>";
                return RedirectToAction("Edit");
            }
            else if (year == yyyy && month == mm && day > dd)
            {
                TempData["testmsg"] = "<script>alert('Incorrect Birthday');</script>";
                return RedirectToAction("Edit");
            }

            else if (ModelState.IsValid)
            {
                db.Entry(artist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artist);
}

```

