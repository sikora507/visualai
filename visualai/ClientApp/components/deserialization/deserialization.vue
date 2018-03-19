<template>
    <div>
        <h2>Network Deserialization - max {{maxNeurons}} neurons</h2>
        <vue-slider v-model="maxNeurons" v-bind="sliderOptions"></vue-slider>
        <label>Neuron types</label>
        <textarea class="form-control" type="text" readonly>{{ neuronTypes }}</textarea>
        <label>Connection presences</label>
        <textarea class="form-control" type="text" readonly>{{ connectionPresences }}</textarea>
        <label>Connection weights</label>
        <textarea class="form-control" type="text" readonly>{{ connectionWeights }}</textarea>
        <button class="btn btn-primary">Deserialize!</button>
    </div>
</template>
<script>
    import vueSlider from 'vue-slider-component';

    var activationFunctions = ['Sigmoid', 'Gaussian', 'Sinc', 'Sine', 'Tanh'];

    export default {
        data: function () {
            return {
                maxNeurons: 20,
                sliderOptions: {
                    min: 5,
                    max: 50,
                    interval: 1,
                    tooltip: false,
                    processStyle: {
                        "backgroundColor": "gray"
                    }
                },
                bitsPrecision: 8
            }
        },
        computed: {
            neuronTypes: function () {
                var chosenFunctions = [];
                for (var i = 0; i < this.maxNeurons; ++i) {
                    var randomFunctionIndex = Math.floor(Math.random() * activationFunctions.length);
                    var chosenFunction = activationFunctions[randomFunctionIndex];
                    chosenFunctions.push(chosenFunction);
                }
                return chosenFunctions.join(', ');
            },
            connectionPresences: function () {
                var connectionPresences = [];
                for (var i = 0; i < this.maxNeurons * this.maxNeurons; ++i) {
                    var hasConnection = Math.round(Math.random());
                    hasConnection ? connectionPresences.push(true) : connectionPresences.push(false);
                }
                return connectionPresences.join(', ');
            },
            connectionWeights: function () {
                var binaryWeights = [];
                for (var i = 0; i < this.maxNeurons * this.maxNeurons; ++i) {
                    var bitsBuffer = [];
                    for (var b = 0; b < this.bitsPrecision; b++) {
                        var bit = Math.round(Math.random());
                        bitsBuffer.push(bit);
                    }
                    binaryWeights.push(bitsBuffer.join(''));
                }
                return binaryWeights.join(', ');
            }
        },
        mounted: function () {
            fetch('api/simpleNetwork/GetBitsPrecision')
                .then(data => data.json())
                .then(result => this.bitsPrecision = result);
        },
        components: {
            vueSlider
        }
    }
</script>
<style scoped>
    button, textarea {
        margin: 0 0 20px 0;
    }
    textarea {
        height: 80px;
    }
</style>