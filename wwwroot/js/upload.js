function handleFileSelect(event) {
    const fileInput = event.target;
    const preview = document.getElementById('preview');
    const file = fileInput.files[0];
    const reader = new FileReader();

    reader.onloadend = function () {
        preview.src = reader.result;
    }

    if (file) {
        reader.readAsDataURL(file);
    } else {
        preview.src = "";
    }
}

function handleSubmit(event) {
    event.preventDefault();
    const form = event.target;
    const formData = new FormData(form);

    fetch(form.action, {
        method: 'POST',
        body: formData
    })
        .then(response => response.json())
        .then(data => {
            alert(`Song title: ${data.title}\nArtist name: ${data.artist}\nGenre: ${data.genre}\nFile name: ${data.fileName}`);
            form.reset();
            document.getElementById('preview').src = "";
        })
        .catch(error => {
            console.error(error);
        });
}

document.getElementById('song-file').addEventListener('change', handleFileSelect);
document.getElementById('song-form').addEventListener('submit', handleSubmit);