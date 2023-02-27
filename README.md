# Solution

I will describe here all related to the solution I've implemented here in following sections:

- Initial considerations

- Change log

- Thoughts and doubts

## Initial considerations

I've considered this as a test. I mean two things with that.

One thing is that probably I've made some overkill solution for some parts in order to show part of the knowledge and the experience I have. As you said in the exercise, it's a very simple API with only one endpoint, but I've prepared it for growing a lot.

Second part is that I've have made some changes that required some alignments with different people in the company before applying them.

For example, I've changed the contract of the API. That requires an alignment with the clients that consume it. Another approach could have be to keep the old contract and create a new endpoint with a new contract, calling the same code (except the corresponding for the contract).

Other example is that I've changed the target framework, and that should be align with devops/delivery team, in order to have installed the right one in the corresponding environment.

Another example is that I've applied a couple changes in the logic of the email normalizer, and the Normal User creation money gifter, since there were some gaps. This should be aligned with product team.

I've considered the email normalizer a little custom and weird... I would have user a validator instead, but keeping the main logic of the transformation, and considering it's a little custom, I've put it in the Domain layer. If it were standard I would have put it on the Infrastructure layer (project that I didn't create, by the way).

The last example it's the refactor itself. It's a really big refactor, and before applying some big reestructuring of a code, it should be aligned with the development team. There are some changes very obvious, but others may have different approaches. I've experimented in the past some colleagues that has another thought and refactor the code using another patterns because they like them more... and then another colleague changing again to another pattern or structure he likes. I think it's not the way forward to go.

I've left some test classes without being implemented (with some TODO comments), because that "2" hours were left behind a lot of time ago, and I think you can guess, extrapolating the rest of the tests I've implemented what I would have done there. For sure, in a real production system, I would have implemented them covering success and failure scenarios.

I also would like to change the database for a SQL localdb server over EntityFramework, but again, I think I'm expending too much time, and it's not adding much more. If you want me to do it, just tell me and I can do.

## Change log

- Removed redundant comment

- Merge composite ifs

- Compound assignments

- Create custom exceptions

- Improve exception handling

- Added more cases to API input parameters validation

- Having own unique files per type

- Migrate to net 7 (initial framework was out of support)

- Standardize API

	- Use rest route "POST &lt;controller&gt;"

	- Receive a dto in the body insted of a set of parameters in the url

	- Changing the response dto. One for success, and other for errors

	- Return http status codes

	- Return list of errors instead of big compound string

- Structure the solution with a DDD approach (presentation-application-domain-infrastructure/persistence)

- Structure test projects respecting corresponding code projects structure to facilitate their mapping

- Adding NLog, and configuring to log to file (removing api standard messages to clearly see the application messages)

- Applying CQRS pattern to ensure isolation of use cases and their implementation. (It also helps with database load management, but didn't apply anything in that sense)

- Applying mediator pattern through MediaTR to get access to the application services

- Applying some kind of Unit Of Work pattern to have high level transactions

- Applying Repository pattern to manage each domain type persistence (partially implemented since there's no need for more)

- Applying some Factory patterns to build up some classes

- Applying Adapter patterns to compound in a extensible way several transformations to new users

- Using Automapper to map objects between different layers

- Extracting middleware classes to group dependencies

- Modified initial tests to integration tests

- Created structure of tests

- Implemented a lot of unit and integration tests (some missing with TODO comment there)


## Thoughts and doubts

In my opinion, the key part of the exercise is how to implement the modifications over new created users with a good design respecting SOLID.

I have to confess that it gave me some headache, because I tried different approaches and I really didn't like them all.

At the end, I've decided to apply some kind of variant of a decorator/adapter, but my first thoughts were about applying a direct decorator with some kind of abstract factories that builds me the specific Users and the UserCreationGifters, but didn't like the result. Maybe with some peering I could have seen my mistake there.

I would have like to apply more validations in different layers, but again, it's time consuming, and it's not adding much more to the test.

# Backend.TechChallenge

A developer went on vacation and several issues arose in the project that needed to be resolved.

The webAPI works, but it has many flaws in architecture, code quality, testing and etc.

We need you to refactor the code of this project.

Remember to treat it as a refactoring of a final code, which will go to production and has to be as good as possible.

## What we expect to find in the Challenge

In the result of the refactoring we would like to find:

- Object-oriented programming.

- An architectural model. The one that you consider most applicable or that you have more experience.

- The Clean Code concepts that you consider important.

- The best unit tests you can do and with the code coverage you consider important.

- A polymorphic system or some design pattern. The one that fits the most or that you like the most.

- Transversal/crosscutting concepts that you consider important to a webAPI in production such as logging, validation, exception handling...

- REST concepts, SOLID principles and good practices applied.

- And you want to take more time in the challenge you can change the type of persistence (currently TXT file), but consider that your new implementation should be working.

Do the best you can.


## How much time do you have for the challenge

It is a small WebAPI and normally a good refactoring can be done in about 2 hours.

But we know that each one has its speed and in general we prefer to prioritize the quality of delivery, so there is no time limit.


## As you must deliver the challenge once finished

For you to do the challenge you must create a branch or a fork from this one (main).

And once you have finished the refactoring you can send us:

* The link of your branch on Github
* The link of a PR from your branch to the original repo
