<template>
    <div class="function">
        <h3>{{name}}</h3>
        <h4 class="factor">{{scalingFactor}}*x</h4>
        <vue-slider v-model="scalingFactor" v-bind="options"></vue-slider>
        <div class="preview">
            <chart :width="350" :height="170" :points="chartData"></chart>
        </div>
    </div>
</template>
<script>
    //import Vue from 'vue';
    import Chart from './chart.vue';
    import vueSlider from 'vue-slider-component';

    export default {
        props: ['name', 'action'],
        data: function () {
            return {
                chartData: null,
                scalingFactor: 1,
                options: {
                    min: 0.1,
                    max: 2,
                    interval: 0.1,
                    tooltip: false,
                    processStyle: {
                        "backgroundColor": "gray"
                    }
                }
            }
        },
        mounted() {
            this.getData();
        },
        methods: {
            getData: function () {
                fetch(`api/ActivationFunctions/${this.action}?scale=${this.scalingFactor}`)
                    .then(response => response.json())
                    .then(data => {
                        this.chartData = data;
                    });
            }
        },
        watch: {
            scalingFactor: function () {
                this.getData();
            }
        },
        components: {
            Chart,
            vueSlider
        }
    }
</script>
<style scoped>
    .function {
        position: relative;
        text-align: center;
        width: 400px;
        margin-bottom: 20px;
        border: 1px solid black;
        border-radius: 10px;
        overflow: hidden;
    }
    .preview {
        background-color: cornsilk;
        flex-grow: 0;
    }
    button {
        position: absolute;
        top: 15px;
        right: 15px;
    }
    .factor {
        position: absolute;
        top: 15px;
        left: 15px;
    }
</style>