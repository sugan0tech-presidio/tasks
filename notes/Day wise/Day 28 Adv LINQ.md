### scaffolded code with pre-existing `pubs` db
```
 Scaffold-DbContext "Data Source=B4RBBX3\SQLEXPRESS;Integrated Security=true;Initial Catalog=pubs" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Model
```

> Note there should not be any double slash it's only for strings in c#


- For results of DbContext, which will be in quiriable state. which means upon accessing the data it will fetch the details from db. ```
var authors = context.Authors;
- For the data to be pre loaded just add `.ToList()`
`var authors = context.Authors.ToList();`

> So for any LINQ applied to context will execute the query right there.



# GroupBy

```csharp
            pubsContext context = new pubsContext();
            var books = context.Titles
                        .GroupBy(t => t.PubId, t => t.Pub, (pid, title)=>new {Key=pid,TitleCount=title.Count() });
```
- `.GroupBY( KeySelector, ElementSelector, ResultSelector)`
- ==KeySelector== - the key to be used for grouping
- ==ElementSelector== - any element to be used for aggregation
- ==ResultSelector== - function to aggrigate the results ( grouped Key and result list for aggregated data)