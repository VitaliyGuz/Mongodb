'use strict';
var superagent = require('supertest');
var app = require('../server/app.js');

function request() {
    return superagent(app.listen());
}

describe('Routes', function() {
    describe('GET /', function() {
        it('should return 404', function(done) {
            request()
                .get('/')
                .expect(404, done);
        });
    });
    describe('GET /books', function() {
        it('should return 200', function(done) {
            request()
                .get('/books')
                .expect('Content-Type', /json/)
                .expect(200, done);
        });
    });
    describe('GET /books/notfound', function() {
        it('should return 500', function(done) {
            request()
                .get('/books/notfound')
                .expect(500, done);
        });
    });
});