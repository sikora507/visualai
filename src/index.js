import Vue from 'vue'
import Hello from './app/hello.vue'

var vm = new Vue({
    el: '#app',
    render: h => h(Hello),
    components: { Hello }
})