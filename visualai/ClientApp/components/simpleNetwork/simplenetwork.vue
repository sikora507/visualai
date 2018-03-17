<template>
    <div>
        <h2>Simple neural network</h2>
        <p>2 input signals 3 hidden neurons and single output. 3 layers with step by step walkthrough.</p>
        <div class="text-center">
            <button class="btn btn-primary" @click="nextStep">Process next step</button>
        </div>
        <div id="visualization"></div>
    </div>
</template>
<script>
    import { DataSet, Network } from 'vis';
    var nodes = null;
    export default {
        mounted: function () {
            var container = document.getElementById('visualization');
            fetch(`api/SimpleNetwork/GetSimpleNetwork`)
                .then(response => response.json())
                .then(data => {
                    nodes = new DataSet();
                    data.nodes.forEach((item) => { nodes.add(item); });
                    var network = new Network(container, { nodes: nodes, edges: data.edges }, {
                        nodes: {
                            shape: 'box',
                            color: {
                                background: 'cornsilk',
                                border: 'gray',
                                highlight: {
                                    background: 'cornsilk', border: 'gray'
                                }
                            }
                        },
                        edges: {
                            arrows: {
                                to: {
                                    enabled: true
                                }
                            }
                        },
                        layout: {
                            hierarchical: {
                                direction: 'LR',
                                sortMethod: 'directed'
                            }
                        },
                        interaction: {
                            //dragNodes: false,
                            //dragView: false,
                            hoverConnectedEdges: false,
                            //selectable: false,
                            selectConnectedEdges: false,
                        }
                    });
                });
        },
        methods: {
            nextStep: function () {
                fetch(`api/SimpleNetwork/UpdateNetwork`)
                    .then(response => response.json())
                    .then(data => {
                        data.nodes.forEach((item) => {
                            nodes.update(item);
                        });
                    });
            }
        }
    }
</script>
<style scoped>
    #visualization {
        height: 500px;
    }
</style>