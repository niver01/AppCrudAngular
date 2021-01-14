import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ITaxpayer } from './../../../models/ITaxpayer';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ApiTaxpayerService } from './../../../service/api-taxpayer.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { IResponse } from 'src/app/models/IResponse';

@Component({
  selector: 'app-dialog-taxpayer',
  templateUrl: './dialog-taxpayer.component.html',
  styleUrls: ['./dialog-taxpayer.component.scss'],
})
export class DialogTaxpayerComponent implements OnInit {
  public taxpayerForm: FormGroup;
  private _duration: number = 5000;

  constructor(
    private _apiTaxpayerService: ApiTaxpayerService,
    private _formBuilder: FormBuilder,
    private _dialogRef: MatDialogRef<DialogTaxpayerComponent>,
    private _snackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public taxpayer: ITaxpayer
  ) {}

  ngOnInit(): void {
    this.initForm();
  }

  private initForm(): void {
    this.taxpayerForm = this._formBuilder.group({
      idContribuyente: [this.taxpayer ? this.taxpayer.idContribuyente : 0],
      nombre: [this.taxpayer ? this.taxpayer.nombre : '', Validators.required],
      estado: [true],
    });
  }

  async onSave(): Promise<void> {
    if (this.taxpayerForm.valid) {
      const taxpayer: ITaxpayer = this.taxpayerForm.value as ITaxpayer;
      let res: IResponse<any>;

      try {
        if (this.taxpayer === null) {
          res = await this._apiTaxpayerService.add(taxpayer).toPromise();
        } else {
          res = await this._apiTaxpayerService.update(taxpayer).toPromise();
        }

        if (res.result) {
          this._snackBar.open(res.message, '', {
            duration: this._duration,
          });
          this._dialogRef.close(true);
        }
        {
          this._snackBar.open(res.message, '', {
            duration: this._duration,
          });
        }
      } catch (err) {
        this._snackBar.open('Ocurrio un error inesperado.', '', {
          duration: this._duration,
        });
        console.error(err);
      }
    }
  }
}
