<template>
    <div>
        <h2>Simple neural network</h2>
        <p>2 input signals 3 hidden neurons and single output. 3 layers with step by step walkthrough.</p>
        <div id="visualization"></div>
    </div>
</template>
<script>
    import { DataSet, Network } from 'vis';
    export default {
        mounted: function () {
            var container = document.getElementById('visualization');
            // create an array with nodes
            var nodes = new DataSet([
                { id: 1, label: 'Node 1' },
                { id: 2, label: 'Node 2' },
                { id: 3, label: 'Node 3' },
                { id: 4, label: 'Node 4' },
                { id: 5, label: 'Node 5' }
            ]);

            // create an array with edges
            var edges = new DataSet([
                { from: 1, to: 3 },
                { from: 1, to: 2 },
                { from: 2, to: 4 },
                { from: 2, to: 5 }
            ]);

            var data = {
                nodes: nodes,
                edges: edges
            };
            var options = {};

            var network = new Network(container, data, options);
        }
    }
</script>
<style>
</style>