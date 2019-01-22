#include "RESTEndpoint.hh"
#include "pistache/endpoint.h"

using namespace Duck;
using namespace Pistache;
using namespace Rest;


void RESTEndpoint::initEndpoint(size_t thr)
{
     auto opts = Http::Endpoint::options()
            .threads(thr)
            .flags(Tcp::Options::InstallSignalHandler);
    httpEndpoint->init(opts);
    initRoutes();
}

void RESTEndpoint::initRoutes()
{
    Routes::Get(router, "/", Routes::bind(&RESTEndpoint::serverInfo, this));
    Routes::Post(router, "/greetings/:name", Routes::bind(&RESTEndpoint::greetings, this));
}

void RESTEndpoint::serverInfo(const Rest::Request& request, Http::ResponseWriter response)
{
    response.send(Pistache::Http::Code::Ok, "REST server ver. 0.1\n");
}

void RESTEndpoint::greetings(const Rest::Request& request, Http::ResponseWriter response)
{
    auto name = request.param(":name").as<std::string>();
    response.send(Pistache::Http::Code::Ok, "Hi "+ name +" from your server! :)\n");
}

void RESTEndpoint::start() {
    httpEndpoint->setHandler(router.handler());
    httpEndpoint->serve();
}

void RESTEndpoint::shutdown() {
    httpEndpoint->shutdown();
}