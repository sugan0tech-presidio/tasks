# SOLID
| S<br> | Single Responsiblity                                                                               |
| ----- | -------------------------------------------------------------------------------------------------- |
| O     | Open Closed Principle ( open for inheritance & closed for modification )                           |
| L     | Liskov substitution principle ( if we substitute parent with child, it should not cause error)<br> |
| I     | Interface segregation                                                                              |
| D     | Dependency Inversion                                                                               |

---
# CQRS Command and Query Responsiblity Segrigation
[ref](https://learn.microsoft.com/en-us/azure/architecture/patterns/cqrs)

- A pattern separates READ and WRITE operations to a data store.
- Maximizes Performance, scalability & security
- Having a read only replica ( with optimized schema for data retrieval )
- Receive data can be fetched in the format of [materialized view](https://learn.microsoft.com/en-us/azure/architecture/patterns/materialized-view)
![[Pasted image 20240523104351.png]]


# # Event Sourcing Pattern

[ref](https://learn.microsoft.com/en-us/azure/architecture/patterns/event-sourcing)

- Storing app writes in terms of events, so it can be reproduced and notified the read operations about possible update.

- To be precise it is being stored in a append only store.
- Those events will be sent by the app code, each represents action occuered to a data.

![[Pasted image 20240523104240.png]]
