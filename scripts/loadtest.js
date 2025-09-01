import http from 'k6/http';
import { sleep, check } from 'k6';

// Load test configuration
export let options = {
    vus: 1000,           // number of concurrent virtual users
    duration: '2m',    // total test duration
    thresholds: {
        http_req_duration: ['p(95)<500'], // 95% of requests should be below 500ms
    },
};

// Test scenario
export default function () {
    // 1. Load main page
    let res = http.get('http://10.0.4.10:30080/');

    // Optional: check for successful response
    check(res, {
        'page loaded successfully': (r) => r.status === 200,
    });

    // 2. Optionally, load static assets (JS, CSS)
    // let js = http.get('https://yourapp.com/_framework/blazor.server.js');
    // let css = http.get('https://yourapp.com/css/app.css');

    // 3. Simulate user "idle time" on the page
    sleep(30); // user stays on page for 30 seconds

    // 4. Repeat interactions if needed
    // Example: click a button that triggers an API call
    // let apiRes = http.get('https://yourapp.com/api/values');
    // check(apiRes, { 'API call OK': (r) => r.status === 200 });

    // Sleep again to simulate more idle time
    sleep(60);
}
