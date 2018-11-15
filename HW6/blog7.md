---
title: Homework 6
layout: default
---
# Software Engineering Homework

## Homework 6

For this homework we were tasked with making an MVC 5 web application using a relational database, and implementing javascript to handle requests from the page without needing to fully refreash the page.

1. [Assignment](http://www.wou.edu/~morses/classes/cs46x/assignments/HW7_1819.html)
2. [Repository](https://github.com/ABergman7/ABergman7.github.io/tree/master/HW7/Homework7) 


## Final Product
<video width="1000" height="666" controls="controls">
  <source src="/HW7/Pictures/HW7.mp4" type="video/mp4" />
</video>

## Set Up
  The database is nomrally the first thing that I begin to hammer out for homework assignments. As from the previous homeworks we impliment an up and down script for the data base, and then I scaffolded the model from there. 

![Picture](/HW7/Pictures/Database.PNG)

    Aside from the Database we were tasked with using a private key from Giphy.com and putting that key in a private folder outside of the repository. Then we went into our Web.config file and re-adjusted our appsettings to read from the config file outside of our repo.

![Picture2](/HW7/Pictures/config.PNG)


## Coding 
    After setting up the appsettings, I went and made a blank controller and scoffolded a view from it. Then I went and made the controller to handle the API, since most of the work was done with the API controller we had to adjust the routes to each controller. 


### RouteConfig
```csharp
    public class RouteConfig
        {
            public static void RegisterRoutes(RouteCollection routes)
            {
                routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

                routes.MapRoute(
                    name: "GifApiRoute",
                    url: "{controller}/{action}/{gifInput}",
                    defaults: new { controller = "GIFAPI", action = "Sentence" }
                    );

                routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Requests", action = "Index", id = UrlParameter.Optional }
                );
            }
        }
```

    As for the code for the controller and the javascript file. We had to make the API controller use a JsonResult action method and was tasked with handleing the request as well as sending updates to the model. Meanwhile, the script was tasked with using ajax and making filters for words and outputting the lines back out to the view without needing to refreash the page.



### Controller
 ```csharp

  public JsonResult Sentence(string gifInput)
        {
            string gifKey = System.Configuration.ConfigurationManager.AppSettings["GKey"];

            string gifRequest = "https://api.giphy.com/v1/stickers/translate?api_key=" + gifKey + "&s=" + gifInput;

            Debug.WriteLine(gifRequest);
            var req = WebRequest.Create(gifRequest);
            req.ContentType = "aaplication/json; charset=utf-8";
            var res = (HttpWebResponse)req.GetResponse();

            string content;

            using (var stream = new StreamReader(res.GetResponseStream()))
            {
                content = stream.ReadToEnd();
                stream.Close();
            }

            
            string data = JObject.Parse(content)["data"].ToString();
            string url = JObject.Parse(data)["embed_url"].ToString();

            var gifSticker = new { embed_url = url };
            

            var ip = Request.UserHostAddress;
            var browser = Request.Browser.Type;

            var model = new Models.Request
            {
                IPAddress = ip,
                Browser = browser,
                DateRequested = DateTime.Now,
                RequestType = gifInput
            };

            requestContext.Requests.Add(model);
            requestContext.SaveChanges();

            return Json(gifSticker, JsonRequestBehavior.AllowGet);
        }

 ```   
### JavaScript
```javascript

   
    if (event.keyCode == 32 || event.key === " ")
    {
        
        var req = $("#gifInput").val().toString().toLowerCase();
       // console.log(req);
        var reqList = req.split(" ");
        var reqLast = reqList.pop();
       // console.log(reqList);
        var reqLen = reqList.length;
        // Init as "in it" not initialize (borrowed haskell terminology)
        var reqInit = reqList[reqLen - 1];
        console.log(reqInit);


        if (adjectives.includes(reqLast) || nouns.includes(reqLast) || verbs.includes(reqLast)) {
            console.log("Checkpoint 1 get sticker");
            var source = "/GIFAPI/Sentence/" + reqLast;
            console.log(source);

            $.ajax(
                {
                    type: "GET",
                    dataType: "json",
                    url: source,
                    success: outSticker,
                    error: ajaxError
                })
        }
        else {
            $(".output").append(reqLast + " ");
        }

    }


    function outSticker(gifSticker) {
        //console.log("Checkpoint 2 sticker output: " + gifSticker);
        $(".output").append("<iframe src='" + gifSticker.embed_url + "'height ='150' width = '150' frameBorder='0' align = 'middle'>");
    }
    
    function ajaxError() {
    console.log("Checkpoint 3 bad ajax");
    }

```


## Logging
    Finally after we implimented the webpage, we were supposed to use the database to log each request that was sent out. Here is a query of the last few reqeusts:

![Picture4](HW7/Pictures/Query.PNG)