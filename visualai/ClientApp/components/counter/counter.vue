<template>
    <div>
        <h1>Counter</h1>

        <p>This is a simple example of a Vue.js component.</p>

        <p>Current count: <strong>{{ currentcount }}</strong></p>

        <button @click="incrementCounter">Increment</button>
    </div>
</template>

<script>
    import Vue from 'vue';

    export default {
        data: function () {
            return {
                currentcount: 0
            }
        },
        methods: {
            incrementCounter: function () {
                this.currentcount++;
            }
        }
    }
</script>
