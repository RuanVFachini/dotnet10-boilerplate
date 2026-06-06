import http from 'k6/http';
import { sleep } from 'k6';
export const options = {
    vus: 5000,
    duration: '30s',
    insecureSkipTLSVerify: true,
};
export default function () {
    http.get('https://localhost:7271/todos');
    sleep(1);
}
