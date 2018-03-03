import Vue from 'vue'
import Hello from './app/hello.vue'
import 'bootstrap/dist/css/bootstrap.css'
var vm = new Vue({
    el: '#app',
    render: h => h(Hello),
    components: { Hello }
})