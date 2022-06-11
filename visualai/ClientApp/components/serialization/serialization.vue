<template>
    <div>
        <h2>Network serialization to genome</h2>
        <div class="row">
            <div class="col-md-5">
                <simple-network></simple-network>
                <raw-chromosome :rawData="rawData"></raw-chromosome>
            </div>
            <div class="col-md-7">
                <acti-functions :data="actiFunctions"></acti-functions>
                <connections-presence :connections="connectionPresence"></connections-presence>
                <weights-binary :weights="weightsBinary" :neuronsCount="neuronsCount"></weights-binary>
                <weights-decimal :weights="weightsDecimal"></weights-decimal>
            </div>
            </div>
        </div>
    </template>
    <script>
        import SimpleNetwork from '../simpleNetwork/simplenetwork.vue';
        import ActivationFunctions from './actiFunctions.vue';
        import WeightsBinary from './weightsBinary.vue';
        import WeightsDecimal from './weightsDecimal.vue';
        import ConnectionsPresence from './connectionsPresence.vue';
        import RawChromosome from './rawChromosome.vue';

        export default {
            components: {
                'simple-network': SimpleNetwork,
                'acti-functions': ActivationFunctions,
                'weights-binary': WeightsBinary,
                'weights-decimal': WeightsDecimal,
                'connections-presence': ConnectionsPresence,
                'raw-chromosome': RawChromosome
            },
            data: function () {
                return {
                    actiFunctions: [],
                    connectionPresence: [],
                    weightsBinary: [],
                    weightsDecimal: [],
                    neuronsCount: 0,
                    rawData: {}
                }
            },
            mounted: function () {
                fetch(`/api/simpleNetwork/ToConnectionMatrix`)
                    .then(response => response.json())
                    .then(data => {
                        this.rawData = data;
                        this.actiFunctions = data.actiFunctions;
                        this.connectionPresence = data.connectionPresence;
                        this.weightsBinary = data.weightsBinary;
                        this.weightsDecimal = data.weightsDecimal;
                        this.neuronsCount = data.actiFunctions.length;
                    });
            }
        }
    </script>
    <style>

    </style>
