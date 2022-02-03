# Github APIs
The objective of this project was to identify the number of PRs approved by each user.

There is a groups CRUD, the purpose of the groups is to group repositories by departments or squads.

Ex:
repository1 and repository2 are part of squad x, so you can get the approval ranking of a certain group.

As the github APIs work with a maximum pagination of 100, the data is persisted in a database, so there is no need for the query that takes a long time.

## Backlog
The project is a v1, and has several points of improvement, among them are:

- [ ] Implement logs;
- [ ] Return ranking filtering by date;
- [ ] Data return model with possible errors;
- [ ] Ranking of who made more comments, more rejections;
- [ ] EF mapping can be improved;
- [ ] CRUD of groups can be improved;

The project was developed with the intention of obtaining other data besides pull and review, for this is to extend the GithubAPI.Service.Database.IGithubDataService interface and implement the UpdateDatabase, so the method will be automatically called by the database/sync.

## How to run the project?

1- First you need to run docker compose in the project root:
<pre><code>docker compose up
</code></pre>


2 - Create a github token.
https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/creating-a-personal-access-token

3 - Insert the token in appsettings.json along with the username

<pre><code>  "GithubConfiguration": {
    "Token": "YOUR GITHUB TOKEN",
    "User": "YOUR GITHUB USER"
  }
</code></pre>


4 - Run the project and call: 
<pre><code> POST /api/database/migration
</code></pre>

5 - You can use <code>GithubAPI.Context.Seed</code> and create groups and repositories or use groups crud to create.

6 - End


## API docs
<code>https://docs.github.com/pt/rest/reference/pulls</code>


## Important
The project was made for a punctual and shared data extraction with the objective of helping people with the same need, it has several points that can be improved.
