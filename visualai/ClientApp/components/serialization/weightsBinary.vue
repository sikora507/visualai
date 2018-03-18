<template>
    <div>
        <h4>Weights binary</h4>
        <table class="table table-bordered">
            <thead>
                <tr>
                    <th>#</th>
                    <th v-for="(w, index) in neurons">{{index+1}}</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(id, row) in neurons">
                    <td>{{row+1}}</td>
                    <td v-for="(n, column) in neurons">
                        {{binaryWeights[row*neuronsCount+column]}}
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>
<script>
    export default {
        props: ['weights', 'neuronsCount'],
        data: function () {
            return {
                
            }
        },
        computed: {
            neurons: function () {
                if (!this.neuronsCount) {
                    return [];
                }
                var result = [];
                for (var i = 0; i < this.neuronsCount; i++) {
                    result.push(i + 1);
                }
                return result;
            },
            binaryWeights: function () {
                if (!this.weights || !this.neuronsCount) {
                    return [];
                } else {
                    let result = [];
                    var precision = this.weights.length / this.neuronsCount / this.neuronsCount;
                    for (var row = 0; row < this.neuronsCount; row++) {
                        for (var col = 0; col < this.neuronsCount; col++) {
                            var binary = '';
                            for (var b = 0; b < precision; b++) {
                                binary
                                    += '' + this.weights[row * this.neuronsCount * precision + col * precision + b] + '';
                            }
                            result.push(binary);
                        }
                    }
                    return result;
                }
            }
        }
    }
</script>
<style scoped>
</style>