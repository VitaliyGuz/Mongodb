/**
 * Created by Vitaliy on 11.12.2015.
 */

var koa = require("koa");
var route = require("koa-route");
var parse = require("co-body");
var url = 'mongodb://localhost:27017/test';
var mongoose = require('mongoose');
mongoose.connect(url);

var app = koa();
app.use(route.post("/books", saveBook));
app.use(route.get("/books", getBooks));
app.use(route.get("/books/:id", getBook));
app.use(route.delete("/books/:id", deleteBook));

var bookSchema = mongoose.Schema({
    title:String,
    author:String,
    isbn:Number
});

var book = mongoose.model('book', bookSchema);

function *saveBook(){
    try{
        var bookFromRequest = yield parse(this);
        var response = yield book.create(bookFromRequest);
        this.body = response;
        this.status = 201;
    }catch (_error){
        this.body = _error.message;
        this.status = _error.code;
    };
};

function *deleteBook(id){
    try{
        this.body = yield book.findByIdAndRemove(id);
    }catch (_error){
        this.body = _error.message;
        this.status = _error.code;
    };
};

function *getBooks(){
    try{
        this.body = yield book.find();
    }catch (_error){
        this.body = _error.message;
        this.status = _error.code;
    };
};

function *getBook(id){
    try{
        this.body = yield book.findById(id);
    }catch (_error){
        this.body = _error.message;
        this.status = _error.code;
    };
};

app.listen(3000);
console.log("app started")