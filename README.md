# code challenge

## Tools

- Docker and docker-compose:
  * Those tools are being used to bootstrap the application and the infrastructure dependencies.

## Configure your environment

1. Open project on Visual Studio: 


2. Set docker-compose as startup project:


3. Run Project:

Web App: 

http://localhost:5100


Catalog Api (Products):  

http://localhost:5400/api/product

EF migration will insert sample products during project execution

Order Api:  

http://localhost:5200/api/orders


RabbitMq:

http://localhost:15672


Catalog Db (Sql server)

localhost,1404


Order Db (Sql server)

localhost,1403

-------


## Architecture

We followed principles of the Onion Architecture plus concepts from Clean Code. 

# Architecture model

We adopted the Onion Architecture model with an emphasis on DDD (domain-driven design) and Clean Architecture practices (inspired on Ports and Adapters too) to define the rules of our domain. In this model, the application is divided into 4 (four) main parts:

1. **shared layer** - utilities used by the application with **no domain relationship**;
2. **externals layer** - it contains data types and sub-domain services and from external sources (usually, another micro-service). If you need to store an external data into our domain layer, then evaluate creating a wrapper over it (a model);
3. **domain layer** - it contains the domain models and algorithms to solve our problem without any external dependencies. The models are aggregate roots, persistence-ignorant abstractions, modeled with an emphasis on the problem to be solved and with an attempt to be correct by its definition (making invalid states not representable, as possible);
4. **application layer** - also known as the business layer, this is where we define and execute business rules of the application. Each service might manipulate one or more aggregate models of our domain in a single "unit of work." This layer orchestrates the execution flow to accomplish some functional and non-functional requirements of the application, but ignores details like persistence, caching, configuration, etc. Those are known and well specified, but the application layer doesn't know about its implementation details;
5. **infrastructure layer** - this is where we bind our application to tools and external services that we want to use like databases etc. Its responsibility is to provide the implementation to those services required by the application to run by adapting and delegating when necessary. For example, developers commonly define their domain models with the database in mind. The consequences are that your models will be a hostage to the database persistence model, and not on how they will solve the problem. By abstracting those details from the application, we allow the core of our system (domain + application) to be purely focused on what matters, solving the problem.

![Onion architecture](https://miro.medium.com/max/462/1*0Pg6_UsaKiiEqUV3kf2HXg.png)

## Dependency layer

```mermaid
graph TD
  S[Shared layer]
  E[Externals layer] -.-> S
  D[Domain layer] -.-> S
  D -.-> E
  A[Application layer] -.-> D
  A -.-> E
  A -.-> S
  A -.-> P[Ports]
  I[Infrastructure layer] -.-> A
  I -->|implements| P
  I -.-> S
  B[Bootstrap] -.-> I
```

* Ports are interfaces for non domain services. It could be an external service or an infrastructure service.

## Application core

The application core is a common term used to describe the domain and application layers.

## Domain Entities vs. Persistent Entities

An entity is an overloaded term here and might cause some problems, so let's reserve a space for it.

A domain entity is something that can be persisted; something that can survive an application shutdown, for example. However, the same can be used to describe persistent entities. So, being persistent is not what differentiates them.

The difference is in how they are intended to be used. Database entities (or persistent entities) will follow the database model, no matter if you are using a table, a document, a key-value, or a graph database. Thus, they represent your abstraction by the rules of the database itself, not by the rules of your domain.

Domain entities are pieces of information that can be persistent but that don't have any constraints on how that should be done. Their shape is dictated by the domain and usually, they will be mapped to one or more tables, documents, graphs, persistent entities...

However, good domain modeling will work with aggregates, not really entities. An aggregate can be a single entity, part of an entity, or an aggregate of multiple entities. Those are independent of the persistence layer rules. What does that mean? _A domain entity will ensure that its state is valid by throwing errors when created, or when
getting or setting a property, or when calling a method. It can contain data in a format that might not be appropriate for persistence too._
