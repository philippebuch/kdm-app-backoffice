**Installation**

In the terminal, run:

npm install
npm install nodemon -g

--------------------

Then run:

npm run server

and:

grunt

--------------------

Then go to:

http://localhost:3000/

---

**Update the src**

Changes in /src directory (sass, js, pug) will generate working files into /build.

This can be acheive with:

grunt build
<!-- 
**Update the data**

All data are stored in data/locals.json.
You can edit the file directly
or go to http://localhost:3000/toolbox/data or http://localhost:3000/?mode=data -->