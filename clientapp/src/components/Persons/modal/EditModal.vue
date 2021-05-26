<template>
    <div class="remodal" data-remodal-id="editModal">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Edit Person</h5>
                    <button type="button" class="remodal-close" data-remodal-action="close" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="mb-3 row">
                        <label for="name" class="col-sm-2 col-form-label">Name</label>
                        <div class="col-sm-10">
                            <input type="text" v-model="personName" class="form-control" id="name">
                        </div>
                    </div>
                    <div class="d-grid">
                        <label class="col-sm-2 col-form-label">Organization</label>
                        <div>
                            <Multiselect @multiselect="onUpdate"/>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button data-remodal-action="confirm" v-on:click="editPerson(1)" class="remodal-confirm">Save
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
        name: "EditModal",
        components: {
            Multiselect
        },
        data() {
            return {
                personName: '',
                personOrg: [],
            };
        },
        methods: {
            editPerson: function (id) {
                console.log(`editPerson(${id})`)
                axios.put(`http://localhost:5000/person/${id}`, {
                    "name": 'Test',
                    "organizations": ["string"]
                })
                    .then(res => {
                        localStorage.setItem('selectedPerson', JSON.stringify(res.data))
                        console.log(res.data)
                    })
            },
            onUpdate(data) {
                console.log('onUpdate()')
                this.personOrg = data;
                console.log(this.personOrg)
            }
        }
    }
</script>

<style scoped>

</style>