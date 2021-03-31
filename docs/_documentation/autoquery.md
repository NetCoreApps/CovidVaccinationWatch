---
slug: autoquery
title: AutoQuery Data Endpoint
---

The vaccination data is exposed via ServiceStack's *AutoQuery* feature which allows various ways of filtering the data.

Filtering by location, we can probide `Alabama` as an example.

<div class="gist-cafe-tabs">
  <ul>
    <li><a href="query-data-csharp">C#</a></li>
    <li><a href="query-data-dart">Dart</a></li>
    <li><a href="query-data-typescript">TypeScript</a></li>
  </ul>
  <div>
     <iframe class="gist-cafe-content" src="" frameborder="0" style="height:450px;width:100%;border:1px solid #ddd"></iframe>
  </div>
</div>

Data can also be ordered by providing the type of ordering and the field to order.

<div class="gist-cafe-tabs">
  <ul>
    <li><a href="query-data-ordered-csharp">C#</a></li>
    <li><a href="query-data-ordered-dart">Dart</a></li>
    <li><a href="query-data-ordered-typescript">TypeScript</a></li>
  </ul>
  <div>
     <iframe class="gist-cafe-content" src="" frameborder="0" style="height:450px;width:100%;border:1px solid #ddd"></iframe>
  </div>
</div>

