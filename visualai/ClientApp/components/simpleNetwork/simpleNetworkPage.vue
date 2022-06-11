<template>
    <div>
        <h2>Simple neural network</h2>
        <p>2 input signals 3 hidden neurons and single output. 3 layers with step by step walkthrough.</p>
        <div class="text-center">
            <button class="btn btn-primary" @click="nextStep">Process next step</button>
        </div>
        <simple-network :newData="newData"></simple-network>
    </div>
</template>
<script>
    import { DataSet, Network } from 'vis';
    import SimpleNetwork from './simplenetwork.vue';

    var nodes = null;
    export default {
        data: function (){
            return {
                newData: null
            }
        },
        methods: {
            nextStep: function () {
                fetch(`api/SimpleNetwork/UpdateNetwork`)
                    .then(response => response.json())
                    .then(data => this.newData = data);
            }
        },
        components: {
            'simple-network': SimpleNetwork
        }
    }
</script>
<style scoped>
    #visualization {
        height: 500px;
    }
</style>