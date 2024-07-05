const express = require("express")

const app = express();

const port = 3232;

app.get("/", (req, res) => {
    res.send("hello world - with a change");
})

app.listen(port, () => {
    console.log("listening on port 3232");
})
