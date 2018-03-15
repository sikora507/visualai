import './css/site.css';
import 'bootstrap';
import Vue from 'vue';
import VueRouter from 'vue-router';
Vue.use(VueRouter);

const routes = [
    { path: '/', component: require('./components/home/home.vue') },
    { path: '/activationfunctions', component: require('./components/activationfunctions/activationfunctions.vue') },
    { path: '/simpleNetwork', component: require('./components/simplenetwork/simplenetwork.vue') },
    { path: '/cppn', component: require('./components/cppn/cppn.vue') }
];

new Vue({
    el: '#app-root',
    router: new VueRouter({ mode: 'history', routes: routes }),
    render: h => h(require('./components/app/app.vue'))
});
