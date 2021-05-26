<template>
    <div class="remodal" data-remodal-id="createModal">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Create Person</h5>
                    <button type="button" class="remodal-close" data-remodal-action="close" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="mb-3 row">
                        <label for="createName" class="col-sm-2 col-form-label">Name</label>
                        <div class="col-sm-10">
                            <input type="text" v-model="personName" class="form-control" id="createName">
                        </div>
                    </div>
                    <div class="d-grid">
                        <label class="col-sm-2 col-form-label">Organization</label>
                        <div>
                            <Multiselect @multiselect="onUpdateOrg"/>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button data-remodal-action="confirm" v-on:click="createPerson" class="remodal-confirm">Save
                    </button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import Multiselect from "@/components/Multiselect";
    import axios from "axios";

    export default {
        name: "CreateModal",
        components: {
            Multiselect
        },
        data() {
            return {
                personName: this.personName,
                personOrg: [],
            };
        },
        methods: {
            createPerson: function () {
                console.log("createPerson()")
                console.log("this.personName:", this.personName);
                console.log("this.personOrg:", JSON.stringify(this.personOrg));
                if (this.personName !== '') {
                    axios.post(`http://localhost:5000/person`, {
                        name: this.personName,
                        organizations: this.personOrg
                    })
                        .then(() => {
                            this.$emit('onCreatePerson')
                            this.personName = ''
                            this.personOrg = []
                        })
                        .catch(() => this.$emit('onCreatePerson'))
                }
            },
            onUpdateOrg(data) {
                this.personOrg = data.data;
            }
        }
    }
</script>

<style scoped>

</style>