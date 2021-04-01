---
slug: doc-generation
title: How the documentation is done.
---

## Documentation

[Documentation for the service](https://servicestackapps.github.io/CovidVaccinationWatch/) is created and hosted by GitHub pages from the local repository's `docs` directory.

We've utilized `Instant Client Apps` to help us embed working projects and multiple languages those shows how these services can be used.

## How to embed your own code examples

Instant Client Apps is a free service hosted by ServiceStack for anyone to use to help themselves or their users get up and running with their own ServiceStack services.

Navigate to [`apps.servicestack.net`](https://apps.servicestack.net), provide your base URL of your ServiceStack service, and explore your services until you like the code example being generated.

![](https://github.com/ServiceStack/docs/raw/master/docs/images/apps/instant-apps-example-3.gif)

Once you've selected your service options, use the `embed` link on the right hand side to generate an `iframe` that you can embed in your docs.

For these docs, a simple jQuery-UI Tabs plugin was used in combination with changing each samples iframe `src` attribute to allow examples to be viewed in multiple lanuages.

![](https://raw.githubusercontent.com/ServiceStack/docs/master/docs/images/apps/covid-vac-watch-embed-docs-example-1.png)

This way we could place new examples by using key per example and choose which languages we wanted them to be shown in.

```html
<div class="gist-cafe-tabs">
  <ul>
    <li><a href="query-data|csharp">C#</a></li>
    <li><a href="query-data|typescript">TypeScript</a></li>
    <li><a href="query-data|dart">Dart</a></li>
    <li><a href="query-data|java">Java</a></li>
    <li><a href="query-data|kotlin">Kotlin</a></li>
    <li><a href="query-data|swift">Swift</a></li>
    <li><a href="query-data|vbnet">VB.NET</a></li>
    <li><a href="query-data|fsharp">F#</a></li>
  </ul>
  <div>
     <iframe class="gist-cafe-content" src="" frameborder="0" style="height:450px;width:100%;border:1px solid #ddd"></iframe>
  </div>
</div>
```

Above `query-data` is the name we have given to a specific example and separated by a specific language, eg `our-example|csharp`.

The key `query-data` is then added to a JS object with the `iframe` URL replacing the specific language with `$LANG$`.

```js
// Add examples here with "$LANG$" to replace and match IDs in HTML added into each page.
var nameGistCafeMapping = {
    "get-locations": "https://gist.cafe/embed?gist=https%3A%2F%2Fapps.servicestack.net%2Fgists%2Fcovid-vac-watch.netcore.io%2F$LANG$%2FGetLocations()&title=Get%20Locations&mode=viewonly",
    "query-data": "https://gist.cafe/embed?gist=https%3A%2F%2Fapps.servicestack.net%2Fgists%2Fcovid-vac-watch.netcore.io%2F$LANG$%2FQueryVaccinationRates(Location%3AAlabama)&title=Get%20Locations&mode=viewonly",
    "query-data-ordered": "https://gist.cafe/embed?gist=https%3A%2F%2Fapps.servicestack.net%2Fgists%2Fcovid-vac-watch.netcore.io%2F$LANG$%2FQueryVaccinationRates(OrderByDesc%3ATotalDistributed)&title=Get%20Locations&mode=viewonly",
    "query-data-combined": "https://gist.cafe/embed?gist=https%3A%2F%2Fapps.servicestack.net%2Fgists%2Fcovid-vac-watch.netcore.io%2F$LANG$%2FQueryVaccinationRates(Location%3AAlaska%2COrderByDesc%3ATotalDistributed%2CFields%3A%22Date%2C%20Location%2C%20DailyVaccinations%22)&mode=viewonly"
}
```

Combined with some simple jQueryUI, this allows users of the docs to see concrete examples of how to interact with a service.

```js
function getIFrameUrlByExampleAndLanguage(exampleId) {
    var language = exampleId.split('|')[1];
    var example = exampleId.split('|')[0];
    return nameGistCafeMapping[example].replace('$LANG$',language);
}

$( function() {
    $( ".gist-cafe-tabs" ).tabs({
        beforeLoad: function( event, ui ) {
            if(ui.ajaxSettings.url != null) {
                var url = getIFrameUrlByExampleAndLanguage(ui.ajaxSettings.url)
                $(this).find(".gist-cafe-content").attr("src",url)
            }
            ui.jqXHR.abort();
        }
    });
} );
```

Resulting in a way to put hand crafted docs next to generated code examples.

<div class="gist-cafe-tabs">
  <ul>
    <li><a href="query-data|csharp">C#</a></li>
    <li><a href="query-data|typescript">TypeScript</a></li>
    <li><a href="query-data|dart">Dart</a></li>
    <li><a href="query-data|java">Java</a></li>
    <li><a href="query-data|kotlin">Kotlin</a></li>
    <li><a href="query-data|swift">Swift</a></li>
    <li><a href="query-data|vbnet">VB.NET</a></li>
    <li><a href="query-data|fsharp">F#</a></li>
  </ul>
  <div>
     <iframe class="gist-cafe-content" src="" frameborder="0" style="height:450px;width:100%;border:1px solid #ddd"></iframe>
  </div>
</div>

#### Try [*Instant Client Apps*](https://apps.servicestack.net/) yourself and enhance your documentation for your ServiceStack services!
