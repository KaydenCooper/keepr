import swal from "sweetalert2"

export default class SwalService {

    static toast(title = "Unfollow") {
        // @ts-ignore
        swal.fire({
            title: title,
            type: "success",
            icon: "success",
            timer: 1500,
            toast: true,
            position: "top-right",
            showConfirmButton: false,
            timerProgressBar: true
        })
    }

}
