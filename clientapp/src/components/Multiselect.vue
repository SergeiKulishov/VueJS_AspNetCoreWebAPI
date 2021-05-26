<template>
    <div>
        <Multiselect
                v-model="value"
                placeholder="Select your organizations"
                mode="tags"
                @select="multiselect"
                @deselect="multiselect"
                :options="options"
                :required="true"
        />
    </div>
</template>

<script>
    import Multiselect from '@vueform/multiselect'

    export default {
        components: {
            Multiselect,
        },
        data() {
            return {
                value: null,
                options: [
                    'Oracle',
                    'Google',
                    'Tesla',
                    'Yahoo'
                ],
            }
        },
        props: {
            dataOrg: Array,
        },
        methods: {
            multiselect() {
                this.$emit('multiselect', {
                    data: this.value
                })
            }
        },
        updated() {
            if(this.value === null) {
                this.value = this.dataOrg
            }
        }
    }
</script>

<style src="../../node_modules/@vueform/multiselect/themes/default.css"></style>
