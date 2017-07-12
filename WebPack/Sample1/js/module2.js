var _ = require('lodash')

var people = [{"id":1,"first_name":"Theressa","last_name":"Cussons","email":"tcussons0@google.co.uk","gender":"Female","ip_address":"66.124.92.50"},
{"id":2,"first_name":"Zorana","last_name":"Nunns","email":"znunns1@pbs.org","gender":"Female","ip_address":"243.162.78.208"},
{"id":3,"first_name":"Vergil","last_name":"Inchan","email":"vinchan2@nymag.com","gender":"Male","ip_address":"62.105.234.180"},
{"id":4,"first_name":"Amble","last_name":"O'Fallowne","email":"aofallowne3@wikispaces.com","gender":"Male","ip_address":"77.80.179.102"},
{"id":5,"first_name":"Sam","last_name":"Kenwyn","email":"skenwyn4@so-net.ne.jp","gender":"Male","ip_address":"120.196.74.238"},
{"id":6,"first_name":"Marianne","last_name":"Bricklebank","email":"mbricklebank5@army.mil","gender":"Female","ip_address":"198.205.97.70"},
{"id":7,"first_name":"Anitra","last_name":"Thewys","email":"athewys6@tripadvisor.com","gender":"Female","ip_address":"134.52.193.52"},
{"id":8,"first_name":"Hayley","last_name":"Corzor","email":"hcorzor7@psu.edu","gender":"Female","ip_address":"73.211.203.69"},
{"id":9,"first_name":"Bliss","last_name":"Fiveash","email":"bfiveash8@businessweek.com","gender":"Female","ip_address":"51.3.98.234"},
{"id":10,"first_name":"Petr","last_name":"Germann","email":"pgermann9@tinyurl.com","gender":"Male","ip_address":"224.40.169.174"},
{"id":11,"first_name":"Ruby","last_name":"Askwith","email":"raskwitha@flickr.com","gender":"Female","ip_address":"125.111.15.16"},
{"id":12,"first_name":"Logan","last_name":"Sissot","email":"lsissotb@princeton.edu","gender":"Male","ip_address":"232.166.245.104"},
{"id":13,"first_name":"Lalo","last_name":"Andres","email":"landresc@hubpages.com","gender":"Male","ip_address":"184.119.207.26"},
{"id":14,"first_name":"Delilah","last_name":"Echelle","email":"dechelled@dot.gov","gender":"Female","ip_address":"251.235.12.12"},
{"id":15,"first_name":"Lucinda","last_name":"Ruggs","email":"lruggse@irs.gov","gender":"Female","ip_address":"14.37.159.61"},
{"id":16,"first_name":"Forrester","last_name":"Frandsen","email":"ffrandsenf@chronoengine.com","gender":"Male","ip_address":"44.169.68.34"},
{"id":17,"first_name":"Alf","last_name":"Letrange","email":"aletrangeg@cmu.edu","gender":"Male","ip_address":"117.188.104.97"},
{"id":18,"first_name":"Lita","last_name":"Leist","email":"lleisth@csmonitor.com","gender":"Female","ip_address":"45.240.191.199"},
{"id":19,"first_name":"De witt","last_name":"Mammatt","email":"dmammatti@census.gov","gender":"Male","ip_address":"135.131.84.227"},
{"id":20,"first_name":"Raleigh","last_name":"Rossoni","email":"rrossonij@cisco.com","gender":"Male","ip_address":"251.125.193.47"}];

var femaleCount = _.filter(people,{gender:'Female'}).length;

alert(femaleCount);

console.log("module2")

