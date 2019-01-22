#include "endpoint/RESTEndpoint.hh"
#include "pistache/endpoint.h"

using namespace Duck;
using namespace Pistache;
using namespace Rest;
using namespace std;

int main() {
    Port port(9080);
    int thr = 2;

    Address addr(Ipv4::any(), port);
    Duck::RESTEndpoint stats(addr);

    stats.initEndpoint(thr);
    stats.start();

    stats.shutdown();

}