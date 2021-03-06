/*
Copyright (C) <2015>  <gary@duncodin.it>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as
published by the Free Software Foundation, either version 3 of the
License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

var util = require('util'),
    twitter = require('twitter');
    
var twit = new twitter({
    consumer_key: 'YOUR KEY HERE',
    consumer_secret: 'YOUR SECRET HERE',
    access_token_key: 'YOUR TOKEN KEY HERE',
    access_token_secret: 'YOUR TOKEN SECRET HERE'
});

twit.stream('statuses/filter', {track: '#oscars, #oscars2015'}, function(stream) {
    stream.on('data', function(data) {
        console.log(data);
    });
});
