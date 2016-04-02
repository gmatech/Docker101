'use strict';

var rates = [
    {state: 'CA', rate: 3.15},
    {state: 'OR', rate: 2.95},
    {state: 'WA', rate: 4.95}
]

function findByMatchingProperties(set, properties) {
    return set.filter(function (entry) {
        return Object.keys(properties).every(function (key) {
            return entry[key] === properties[key];
        });
    });
}

exports.register = function (server, options, next) {

    server.route({
        method: 'GET',
        path: '/',
        handler: function (request, reply) {

            reply({ message: 'Welcome to shipping service.' });
        }
    });

    server.route({
        method: 'GET',
        path: '/Shipping/Rates',
        handler: function (request, reply) {

            reply(
                rates
            );
        }
    });

    next();
};


exports.register.attributes = {
    name: 'api'
};
