#include "pistache/endpoint.h"
#include "pistache/router.h"

namespace Duck
{
    using namespace Pistache;
    using namespace Rest;
    using namespace std;

    class RESTEndpoint{

    public:
        RESTEndpoint(Address addr) : httpEndpoint(std::make_shared<Http::Endpoint>(addr)){ }
        void initEndpoint(size_t thr = 2);
        void serverInfo(const Rest::Request& request, Http::ResponseWriter response);
        void greetings(const Rest::Request& request, Http::ResponseWriter response);
        void start();
        void shutdown();

    private:
        void initRoutes();
        std::shared_ptr<Http::Endpoint> httpEndpoint;
        Rest::Router router;
    };
}