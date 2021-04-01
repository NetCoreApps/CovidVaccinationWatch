---
slug: autoquery
title: AutoQuery Data Endpoint
---

The vaccination data is exposed via ServiceStack's *AutoQuery* feature which allows various ways of filtering the data.

Filtering by location, we can probide `Alabama` as an example.

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

### Ordering results

Data can also be ordered by providing the type of ordering and the field to order.

<div class="gist-cafe-tabs">
  <ul>
    <li><a href="query-data-ordered|csharp">C#</a></li>
    <li><a href="query-data-ordered|typescript">TypeScript</a></li>
    <li><a href="query-data-ordered|dart">Dart</a></li>
    <li><a href="query-data-ordered|java">Java</a></li>
    <li><a href="query-data-ordered|kotlin">Kotlin</a></li>
    <li><a href="query-data-ordered|swift">Swift</a></li>
    <li><a href="query-data-ordered|vbnet">VB.NET</a></li>
    <li><a href="query-data-ordered|fsharp">F#</a></li>
  </ul>
  <div>
     <iframe class="gist-cafe-content" src="" frameborder="0" style="height:450px;width:100%;border:1px solid #ddd"></iframe>
  </div>
</div>

### Limiting fields combined

We can also combine date filtering with location and ordering.

<div class="gist-cafe-tabs">
  <ul>
    <li><a href="query-data-combined|csharp">C#</a></li>
    <li><a href="query-data-combined|typescript">TypeScript</a></li>
    <li><a href="query-data-combined|dart">Dart</a></li>
    <li><a href="query-data-combined|java">Java</a></li>
    <li><a href="query-data-combined|kotlin">Kotlin</a></li>
    <li><a href="query-data-combined|swift">Swift</a></li>
    <li><a href="query-data-combined|vbnet">VB.NET</a></li>
    <li><a href="query-data-combined|fsharp">F#</a></li>
  </ul>
  <div>
     <iframe class="gist-cafe-content" src="" frameborder="0" style="height:450px;width:100%;border:1px solid #ddd"></iframe>
  </div>
</div>